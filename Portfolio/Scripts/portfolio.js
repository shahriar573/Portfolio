document.addEventListener('DOMContentLoaded', function () {
    // Smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Skill cards animation
    const skillCards = document.querySelectorAll('.skill-card');
    skillCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-10px)';
        });
        card.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0)';
        });
    });

    // Project cards hover effect
    const projectCards = document.querySelectorAll('.project-card');
    projectCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.boxShadow = '0 8px 16px rgba(0,0,0,0.2)';
        });
        card.addEventListener('mouseleave', function () {
            this.style.boxShadow = '0 2px 4px rgba(0,0,0,0.1)';
        });
    });

    // Back to top button functionality
    const backToTop = document.createElement('button');
    backToTop.innerHTML = '?';
    backToTop.className = 'back-to-top';
    backToTop.style.display = 'none';
    document.body.appendChild(backToTop);

    window.addEventListener('scroll', () => {
        if (window.pageYOffset > 300) {
            backToTop.style.display = 'block';
        } else {
            backToTop.style.display = 'none';
        }
    });

    backToTop.addEventListener('click', () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });

    // ?? External connectivity: fetch user data from Files.com API
    async function loadExternalUsers() {
        try {
            const response = await fetch('/api/filescom/users');
            const users = await response.json();

            const usersSection = document.createElement('section');
            usersSection.id = 'external-users';
            usersSection.innerHTML = '<h2>Connected Users (Files.com)</h2>';

            const ul = document.createElement('ul');
            users.forEach(user => {
                const li = document.createElement('li');
                li.textContent = `${user.username} (${user.email})`;
                ul.appendChild(li);
            });

            usersSection.appendChild(ul);
            document.querySelector('main')?.appendChild(usersSection);
        } catch (err) {
            console.error("Error loading external users:", err);
        }
    }

    // Load external connectivity data on page load
    loadExternalUsers();
});
