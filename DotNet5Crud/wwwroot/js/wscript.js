document.querySelectorAll('.accordion__question').forEach((item) => {
  item.addEventListener('click', (event) => {
    let accCollapse = item.nextElementSibling;
    console.log('cliked');

    // If it DOESN'T have class 'open'
    // A) Open accordion item
    if (!item.classList.contains('open')) {
      console.log('toggle accordion button');

      // A1) Instantly add 'display: block' to the answer to get the height of the div, apply it as style and then hide it again immediately
      accCollapse.style.display = 'block';
      let accHeight = accCollapse.clientHeight;

      // Set timeout to let smooth opening apply
      setTimeout(() => {
        accCollapse.style.height = accHeight + 'px';
        console.log(`****Div height is: ${accHeight}****`);
        // Setting an empty string we let there be the style determined by the stylesheet
        accCollapse.style.display = '';
      }, 1);

      // A2) Remove 'collapse', add 'collapsing' class to .accordion__collapse (sibling) (replacing class text of 'collapse' to 'collapsing')
      accCollapse.classList = 'accordion__collapse collapsing';

      // A3) After x amount of time, remove 'collapsing' class and add 'collapse open' class
      setTimeout(() => {
        console.log('open accordion content');
        accCollapse.classList = 'accordion__collapse collapse open';
      }, 300);

      // If it HAS class 'open'
      // B) Close accordion item
    } else {
      // B1) Remove 'collapse open' from .accordion_collapse, add 'collapsing'
      accCollapse.classList = 'accordion__collapse collapsing';

      setTimeout(() => {
        accCollapse.style.height = '0px';
      }, 1);

      // B2) After x amount of time, remove 'collapsing' class and add 'collapse' class
      setTimeout(() => {
        console.log('close accordion content');
        accCollapse.classList = 'accordion__collapse collapse';
        accCollapse.style.height = '';
      }, 300);
    }

    item.classList.toggle('open');
  });
});
