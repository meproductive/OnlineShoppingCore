const menu = document.querySelector(".menu");
const cartcontent = document.querySelector(".cart-content");
const searchdpcontent = document.querySelector(".search-dp-content");

const dpbtn = document.querySelector(".dp-btn");
const bagdpbtn = document.querySelector(".bag-dp-btn");
const respicon = document.querySelector(".resp-icon");
const respxicon = document.querySelector(".resp-x-icon");

respicon.addEventListener("click", function() {
  menu.classList.toggle("active");
  document.addEventListener("click", function (e) {
      if (!e.composedPath().includes(respicon) &&
          !e.composedPath().includes(menu)
          )
respxicon.addEventListener("click", function() {
  menu.classList.remove("active");
      });
  });
});

bagdpbtn.addEventListener("click", function() {
  cartcontent.classList.toggle("active");
  document.addEventListener("click", function (c) {
    if (!c.composedPath().includes(bagdpbtn) &&
        !c.composedPath().includes(cartcontent)
      ) {
          cartcontent.classList.remove("active");
      }
  });
});

dpbtn.addEventListener("click", function() {
  searchdpcontent.classList.toggle("active");
  document.addEventListener("click", function (b) {
    if (!b.composedPath().includes(dpbtn) &&
        !b.composedPath().includes(searchdpcontent)
      ) {
          searchdpcontent.classList.remove("active");
      }
  });
});

var x, i, j, l, ll, selElmnt, a, b, c;
x = document.getElementsByClassName("custom-select");
l = x.length;
for (i = 0; i < l; i++) {
  selElmnt = x[i].getElementsByTagName("select")[0];
  ll = selElmnt.length;
  a = document.createElement("DIV");
  a.setAttribute("class", "select-selected");
  a.innerHTML = selElmnt.options[selElmnt.selectedIndex].innerHTML;
  x[i].appendChild(a);
  b = document.createElement("DIV");
  b.setAttribute("class", "select-items select-hide");
  for (j = 1; j < ll; j++) {
    c = document.createElement("DIV");
    c.innerHTML = selElmnt.options[j].innerHTML;
    c.addEventListener("click", function(e) {
        var y, i, k, s, h, sl, yl;
        s = this.parentNode.parentNode.getElementsByTagName("select")[0];
        sl = s.length;
        h = this.parentNode.previousSibling;
        for (i = 0; i < sl; i++) {
          if (s.options[i].innerHTML == this.innerHTML) {
            s.selectedIndex = i;
            h.innerHTML = this.innerHTML;
            y = this.parentNode.getElementsByClassName("same-as-selected");
            yl = y.length;
            for (k = 0; k < yl; k++) {
              y[k].removeAttribute("class");
            }
            this.setAttribute("class", "same-as-selected");
            break;
          }
        }
        h.click();
    });
    b.appendChild(c);
  }
  x[i].appendChild(b);
  a.addEventListener("click", function(e) {
    e.stopPropagation();
    closeAllSelect(this);
    this.nextSibling.classList.toggle("select-hide");
    this.classList.toggle("select-arrow-active");
  });
}

function closeAllSelect(elmnt) {
  var x, y, i, xl, yl, arrNo = [];
  x = document.getElementsByClassName("select-items");
  y = document.getElementsByClassName("select-selected");
  xl = x.length;
  yl = y.length;
  for (i = 0; i < yl; i++) {
    if (elmnt == y[i]) {
      arrNo.push(i)
    } else {
      y[i].classList.remove("select-arrow-active");
    }
  }
  for (i = 0; i < xl; i++) {
    if (arrNo.indexOf(i)) {
      x[i].classList.add("select-hide");
    }
  }
}

document.addEventListener("click", closeAllSelect);


let slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  let i;
  let slides = document.getElementsByClassName("mySlides");
  let dots = document.getElementsByClassName("dot");
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " active";
}

function imaFunction() {
  document.getElementById("iamDropdown").classList.toggle("show");
}

windows.onclick = function(event) {
  if (!event.target.matches('.drop-btn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}


function imFunction() {
  document.getElementById("imDropdown").classList.toggle("show");
}

windows.onclick = function(event) {
  if (!event.target.matches('.drop-txt')) {
    var drpdwns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < drpdwns.length; i++) {
      var openDpn = drpdwns[i];
      if (openDpn.classList.contains('show')) {
        openDpn.classList.remove('show');
      }
    }
  }
}

function myFunction(imgs) {
  var expandImg = document.getElementById("expandedImg");
  expandImg.src = imgs.src;
  expandImg.parentElement.style.display = "block";
}


function openPage(pageName,elmnt,color) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }

  tablinks = document.getElementsByClassName("tablink");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].style.backgroundColor = "";
  }

  document.getElementById(pageName).style.display = "block";
  elmnt.style.backgroundColor = color;
}

document.getElementById("defaultOpen").click();


function Tab(pageName,elmnt,color) {
  // Hide all elements with class="tabcontent" by default */
  var i, paneltab, panellink;
  paneltab = document.getElementsByClassName("paneltab");
  for (i = 0; i < paneltab.length; i++) {
    paneltab[i].style.display = "none";
  }

  // Remove the background color of all tablinks/buttons
  panellink = document.getElementsByClassName("panel-link");
  for (i = 0; i < panellink.length; i++) {
    panellink[i].style.backgroundColor = "";
  }

  // Show the specific tab content
  document.getElementById(pageName).style.display = "block";
  elmnt.style.backgroundColor = color;
}

// Get the element with id="defaultOpen" and click on it
document.getElementById("default").click();
