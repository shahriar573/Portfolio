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
            const skillsList = document.getElementById('skills-list');
            const li = document.createElement('li');
            li.textContent = data.name;
            skillsList.appendChild(li);
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
            const projectsList = document.getElementById('projects-list');
            const li = document.createElement('li');
            li.textContent = `${data.title} - ${data.description}`;
            projectsList.appendChild(li);
        });
    }
}