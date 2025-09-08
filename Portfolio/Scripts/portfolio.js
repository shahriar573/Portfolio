// ==========================
// FACTORY METHOD: UI Factory
// ==========================
class ListItemFactory {
    static createItem(type, data, onDelete) {
        const li = document.createElement('li');

        if (type === "skill") {
            li.textContent = data.name + " ";
        } else if (type === "project") {
            li.textContent = `${data.title} - ${data.description} `;
        }

        // Common delete button
        const btn = document.createElement('button');
        btn.textContent = "delete";
        btn.style.marginLeft = "10px";
        btn.onclick = () => onDelete(data.id);

        li.appendChild(btn);
        return li;
    }
}

// =======================================
// ABSTRACT FACTORY: API handler generator
// =======================================
class SkillAPI {
    baseUrl = '/api/skills';

    getAll() {
        return fetch(this.baseUrl).then(res => res.json());
    }
    add(skillName) {
        return fetch(this.baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: skillName })
        }).then(res => res.json());
    }
    delete(id) {
        return fetch(`${this.baseUrl}/${id}`, { method: 'DELETE' });
    }
}

class ProjectAPI {
    baseUrl = '/api/projects';

    getAll() {
        return fetch(this.baseUrl).then(res => res.json());
    }
    add(title, description) {
        return fetch(this.baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, description })
        }).then(res => res.json());
    }
    delete(id) {
        return fetch(`${this.baseUrl}/${id}`, { method: 'DELETE' });
    }
}

const apiFactory = {
    createAPI: function (type) {
        switch (type) {
            case "skill": return new SkillAPI();
            case "project": return new ProjectAPI();
            default: return null;
        }
    }
};

// ==================
// Admin.js Logic
// ==================
document.addEventListener("DOMContentLoaded", function () {
    loadSkills();
    loadProjects();
    connectRealtimeUpdates(); //  Add real-time connection
});

// Load Skills
function loadSkills() {
    const skillAPI = apiFactory.createAPI("skill");
    skillAPI.getAll().then(data => {
        const skillsList = document.getElementById('skills-list');
        skillsList.innerHTML = '';
        data.forEach(skill => {
            const li = ListItemFactory.createItem("skill", skill, deleteSkill);
            skillsList.appendChild(li);
        });
    });
}

// Load Projects
function loadProjects() {
    const projectAPI = apiFactory.createAPI("project");
    projectAPI.getAll().then(data => {
        const projectsList = document.getElementById('projects-list');
        projectsList.innerHTML = '';
        data.forEach(project => {
            const li = ListItemFactory.createItem("project", project, deleteProject);
            projectsList.appendChild(li);
        });
    });
}

// Add Skill
function addSkill() {
    const skillName = document.getElementById('skill-name').value;
    if (skillName) {
        const skillAPI = apiFactory.createAPI("skill");
        skillAPI.add(skillName).then(() => {
            loadSkills();
            document.getElementById('skill-name').value = '';
        });
    }
}

// Add Project
function addProject() {
    const projectTitle = document.getElementById('project-title').value;
    const projectDescription = document.getElementById('project-description').value;
    if (projectTitle && projectDescription) {
        const projectAPI = apiFactory.createAPI("project");
        projectAPI.add(projectTitle, projectDescription).then(() => {
            loadProjects();
            document.getElementById('project-title').value = '';
            document.getElementById('project-description').value = '';
        });
    }
}

// Delete Skill
function deleteSkill(id) {
    const skillAPI = apiFactory.createAPI("skill");
    skillAPI.delete(id).then(res => {
        if (res.ok) loadSkills();
    });
}

// Delete Project
function deleteProject(id) {
    const projectAPI = apiFactory.createAPI("project");
    projectAPI.delete(id).then(res => {
        if (res.ok) loadProjects();
    });
}

// =======================================
//  REAL-TIME: Server-Sent Events (SSE)
// =======================================
function connectRealtimeUpdates() {
    const source = new EventSource('http://127.0.0.1:3000/events');

    source.onmessage = function (event) {
        try {
            const update = JSON.parse(event.data);

            if (update.type === "skill") {
                loadSkills(); // reload skills
            } else if (update.type === "project") {
                loadProjects(); // reload projects
            }

        } catch (e) {
            console.warn("Non-JSON event:", event.data);
        }
    };

    source.onerror = function () {
        console.error("Realtime connection lost.");
    };
}
