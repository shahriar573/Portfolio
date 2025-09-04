// Navigation bar scroll effect
window.addEventListener('scroll', function () {
    const header = document.querySelector('header') || document.querySelector('.header');
    if (window.scrollY > 50) {
        header.classList.add('scrolled');
    } else {
        header.classList.remove('scrolled');
    }
});

// Smooth scroll for nav links
const navLinks = document.querySelectorAll('a.nav-link, nav a');
navLinks.forEach(link => {
    link.addEventListener('click', function (e) {
        if (this.hash) {
            e.preventDefault();
            document.querySelector(this.hash)?.scrollIntoView({ behavior: 'smooth' });
        }
    });
});

// Contact form validation (basic)
document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('contactForm');
    if (form) {
        form.addEventListener('submit', function (e) {
            const name = document.getElementById('name').value.trim();
            const email = document.getElementById('email').value.trim();
            const message = document.getElementById('message').value.trim();
            if (!name || !email || !message) {
                e.preventDefault();
                alert('Please fill in all fields.');
            }
        });
    }

    //  Authentication & Role Display Handling
    const lblUser = document.getElementById('<%= lblUser.ClientID %>');
    const btnLogin = document.getElementById('<%= btnLogin.ClientID %>');
    const btnLogout = document.getElementById('<%= btnLogout.ClientID %>');
    const navAdmin = document.getElementById('<%= navAdmin.ClientID %>');
    const navMember = document.getElementById('<%= navMember.ClientID %>');
    const navGuest = document.getElementById('<%= navGuest.ClientID %>');

    // Check if user session exists (from cookies or session restored in Site.Master.cs)
    let userRole = sessionStorage.getItem('UserRole') || getCookie('UserRole');
    if (userRole) {
        lblUser.textContent = "Logged in as " + userRole;
        btnLogin.style.display = 'none';
        btnLogout.style.display = 'inline-block';

        navAdmin.style.display = userRole === "Admin" ? 'inline-block' : 'none';
        navMember.style.display = userRole === "Admin" || userRole === "Member" ? 'inline-block' : 'none';
        navGuest.style.display = 'none';
    } else {
        lblUser.textContent = "Guest";
        btnLogin.style.display = 'inline-block';
        btnLogout.style.display = 'none';

        navAdmin.style.display = 'none';
        navMember.style.display = 'none';
        navGuest.style.display = 'inline-block';
    }

    // Helper: get cookie by name
    function getCookie(name) {
        const value = `; ${document.cookie}`;
        const parts = value.split(`; ${name}=`);
        if (parts.length === 2) return parts.pop().split(';').shift();
        return null;
    }
});
