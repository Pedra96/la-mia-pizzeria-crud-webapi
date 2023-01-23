function loadList() {

    axios.get('/api/PizzaApi').then((res) => {

        console.log('risultato ok', res);

        if (res.data.length == 0) {

            document.querySelector('.js_no_post').classList.remove('d-none');
            document.querySelector('.js_post_table').classList.add('d-none');

        } else {

            document.querySelector('.js_post_table').classList.remove('d-none');
            document.querySelector('.js_no_post').classList.add('d-none');

            document.querySelector('.js_post_table').innerHTML = '';

            res.data.forEach(post => {

                console.log('post', post);

                document.querySelector('.js_post_table').innerHTML +=
                    `
                                   <div class="col-12 col-md-4 p-2">
                                    <div class="card post h-100">
                                      <img src="${post.image}" class="card-img-top" alt="...">
                                      <div class="card-body">
                                        <h5 class="card-title">${post.title}</h5>
                                        <p class="card-text">${post.description}</p>
                                      </div>
                                    </div>
                                </div>
                             `;
            });
        }
    }).catch((error) => {
        console.log(error);
    });

}
