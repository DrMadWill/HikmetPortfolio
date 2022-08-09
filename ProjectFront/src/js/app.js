'use strict';

const burger = document.querySelector('#navbar i'),
    dropMenu = document.querySelector('#navbar ul'),
    dropCircleMenu = document.querySelectorAll('#navbar ul li');


function hideCircle() {
    for (let i = 0; i < dropMenu.children.length; i++) {
        dropMenu.children[i].children[1].classList.remove('circle')
    }
}

burger.addEventListener('click', () => {
    dropMenu.classList.toggle('flex')
})

dropCircleMenu.forEach(menu => {
    menu.addEventListener('click', () => {
        hideCircle()

        if (!menu.children[1].classList.contains('circle')) {
            menu.children[1].classList.add('circle');
        }

    })
})