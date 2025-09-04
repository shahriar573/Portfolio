// Load existing skills and projects when the page loads
document.addEventListener("DOMContentLoaded", function () {
    loadSkills();
    loadProjects();
});

function loadSkills() {
    fetch('/api/skills')
        .then(response => response.json())
        .then(data => {
            const skillsList = document.getElementById('skills-list');
            skillsList.innerHTML = ''; // clear before reloading
            data.forEach(skill => {
                const li = document.createElement('li');
                li.textContent = skill.name + " ";

                // Add delete button
                const btn = document.createElement('button');
                btn.textContent = "?";
                btn.style.marginLeft = "10px";
                btn.onclick = () => deleteSkill(skill.id);

                li.appendChild(btn);
                skillsList.appendChild(li);
            });
        });
}

function loadProjects() {
    fetch('/api/projects')
        .then(response => response.json())
        .then(data => {
            const projectsList = document.getElementById('projects-list');
            projectsList.innerHTML = ''; // clear before reloading
            data.forEach(project => {
                const li = document.createElement('li');
                li.textContent = `${project.title} - ${project.description} `;

                // Add delete button
                const btn = document.createElement('button');
                btn.textContent = "?";
                btn.style.marginLeft = "10px";
                btn.onclick = () => deleteProject(project.id);

                li.appendChild(btn);
                projectsList.appendChild(li);
            });
        });
}

function addSkill() {
    const skillName = document.getElementById('skill-name').value;
    if (skillName) {
        fetch('/api/skills', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: skillName })
        })
            .then(response => response.json())
            .then(data => {
                loadSkills(); // reload list
                document.getElementById('skill-name').value = ''; // clear input
            });
    }
}

function addProject() {
    const projectTitle = document.getElementById('project-title').value;
    const projectDescription = document.getElementById('project-description').value;
    if (projectTitle && projectDescription) {
        fetch('/api/projects', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title: projectTitle, description: projectDescription })
        })
            .then(response => response.json())
            .then(data => {
                loadProjects(); // reload list
                document.getElementById('project-title').value = '';
                document.getElementById('project-description').value = '';
            });
    }
}

// Delete functions
function deleteSkill(id) {
    fetch(`/api/skills/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                loadSkills(); // reload list
            }
        });
}

function deleteProject(id) {
    fetch(`/api/projects/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                loadProjects(); // reload list
            }
        });
}
