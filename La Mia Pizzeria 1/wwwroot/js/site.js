function searchItem() {
    let searchValue = document.getElementById("SearchBar").value;
    loadList(searchValue);
}

function init() {
    axios.get('/api/PizzaApi').then((res) => {

        console.log('risultato ok', res);

        if (res.data.length == 0) {

            document.getElementById("js_no_post").classList.remove('d-none');
            document.getElementById("js_post_table").classList.add('d-none');

        } else {

            document.getElementById("js_post_table").classList.remove('d-none');
            document.getElementById("js_no_post").classList.add('d-none');

            document.getElementById("js_post_table").innerHTML = '';

            res.data.forEach(pizza => {

                console.log('pizza', pizza);

                document.getElementById("js_post_table").innerHTML +=
                    `
                                   <div class="col-12 col-md-4 p-2">
                                    <div class="card post h-100">
                                        
                                      <img src="${pizza.image}" class="card-img-top" alt="...">
                                      <div class="card-body">
                                        <h5 class="card-title">${pizza.title}</h5>
                                         <a href="/Pizza/DetailsApi/${pizza.id}"
                                        <p class="card-text">${pizza.description}</p>
                                      </div>
                                      </a>
                                    </div>
                                </div>
                             `;
            });
        }
        document.getElementById("spinner-loader").classList.add('d-none');
    }).catch((error) => {
        console.log(error);
    });
}

function loadList(searchString) {

    axios.get('/api/PizzaApi', {
        params: {
            search: searchString
            }
        }).then((res) => {

        console.log('risultato ok', res);

        if (res.data.length == 0) {

            document.getElementById("js_no_found").classList.remove('d-none');
            document.getElementById("js_post_table").classList.add('d-none');

        } else {

            document.getElementById("js_post_table").classList.remove('d-none');
            document.getElementById("js_no_found").classList.add('d-none');

            document.getElementById("js_post_table").innerHTML = '';

            res.data.forEach(pizza => {

                console.log('pizza', pizza);

                document.getElementById("js_post_table").innerHTML +=
                    `
                                   <div class="col-12 col-md-4 p-2">
                                    <div class="card post h-100">
                                        
                                      <img src="${pizza.image}" class="card-img-top" alt="...">
                                      <div class="card-body">
                                        <h5 class="card-title">${pizza.title}</h5>
                                         <a href="/Pizza/DetailsApi/${pizza.id}"
                                        <p class="card-text">${pizza.description}</p>
                                      </div>
                                      </a>
                                    </div>
                                </div>
                             `;
            });
           
            }
    }).catch((error) => {
        console.log(error);
    });

}
