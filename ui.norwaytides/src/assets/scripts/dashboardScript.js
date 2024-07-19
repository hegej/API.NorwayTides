var userMenuDiv = document.getElementById("userMenu");
var userMenu = document.getElementById("userButton");
var navMenuDiv = document.getElementById("nav-content");
var navMenu = document.getElementById("nav-toggle");
document.onclick = check;

function check(e) {
    var target = e && e.target;
    if (!checkParent(target, userMenuDiv)) {
      if (checkParent(target, userMenu)) {
        if (userMenuDiv.classList.contains("invisible")) {
          userMenuDiv.classList.remove("invisible");
        } else {
          userMenuDiv.classList.add("invisible");
        }
      } else {
        userMenuDiv.classList.add("invisible");
      }
    }

    if (!checkParent(target, navMenuDiv)) {
      if (checkParent(target, navMenu)) {
        if (navMenuDiv.classList.contains("hidden")) {
          navMenuDiv.classList.remove("hidden");
        } else {
          navMenuDiv.classList.add("hidden");
        }
      } else {
        navMenuDiv.classList.add("hidden");
      }
    }
  }
  
  document.addEventListener('DOMContentLoaded', function() {
    const homeLink = document.getElementById('home-link');
    const splitScreenLink = document.querySelector('a[href="#split-screen"]');
    const tableDataLink = document.querySelector('a[href="#table-data"]');
  
    function updateActiveLink(activeLink) {
      [homeLink, splitScreenLink, tableDataLink].forEach(link => {
        link.classList.remove('active');
      });
      activeLink.classList.add('active');
    }
  
    homeLink.addEventListener('click', function(e) {
      e.preventDefault();
      location.reload(); //tried to set page to reload on homeLink
    });
  
    splitScreenLink.addEventListener('click', function(e) {
      e.preventDefault();
      if (window.setCurrentPage) {
        window.setCurrentPage('split');
        updateActiveLink(this);
      }
    });
  
    tableDataLink.addEventListener('click', function(e) {
      e.preventDefault();
      updateActiveLink(this);
    });
  });
  
  
  function checkParent(t, elm) {
    while (t.parentNode) {
      if (t == elm) {
        return true;
      }
      t = t.parentNode;
    }
    return false;
  }