fetch('http://localhost:3736/Student')
    .then(x => x.json())
    .then(y => console.log(y));
