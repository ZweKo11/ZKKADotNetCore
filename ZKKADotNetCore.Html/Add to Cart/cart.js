let tblCarts = "Carts";
getCartTable();

function addToCart(id) {
  let lstCart = getCarts();
  let lstProduct = getProducts();

  let items = lstProduct.filter((x) => x.id === id);
  let item = items[0];

  let items2 = lstCart.filter((x) => x.productId === item.id);
  if(items2.length === 0) {
    const requestModel = {
        cartId: uuidv4(),
        productId: item.id,
        name: item.name,
        price: item.price,
        quantity: 1,
      };
      lstCart.push(requestModel);
      const jsonCarts = JSON.stringify(lstCart);
      localStorage.setItem(tblCarts, jsonCarts);
      getCartTable();
  } ;
}

function getCartTable() {
  let lst = getCarts();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    let htmlRow = `
            <tr>
                <td class="col-2">${++count}</td>
                <td class="col-2">${item.name}</td>
                <td class="col-2">${item.price}</td>
                <td class="col-2 text-center">
                    <div class="input-group">
                      <button type="button" class="btn input-group-btn btn-danger px-2" onclick="decreaseProduct('${
                        item.cartId
                      }')">
                          <i class="fa-solid fa-minus text-light"></i>
                      </button>
                      <p class="pt-3 px-2 fs-5">${item.quantity}</p>
                      <button type="button" class="btn input-group-btn btn-info px-2" onclick="increaseProduct('${
                        item.cartId
                      }')">
                          <i class="fa-solid fa-plus"></i>
                      </button>
                    </div>
                  </td>
                  <td class="ps-4">
                      ${item.price * item.quantity} Ks
                  </td>
                  <td>
                      <button type="button" class="btn btn-light" onclick="deleteCart('${item.cartId}')"><i class="fa-solid fa-trash-can text-danger"></i></button>
                  </td>
            </tr>
        `;
    htmlRows += htmlRow;
  });
  $("#cartBody").html(htmlRows);
}

function increaseProduct(id){
    const lst = getCarts();
    let items = lst.filter((x) => x.cartId === id);
    let item = items[0];
    if(!item){
        console.log("no data");
    }else{
        item.quantity += 1;
        updateLocalStorage(tblCarts,lst);
        getCartTable();
    }
}

function decreaseProduct(id){
    const lst = getCarts();
    let items = lst.filter((x) => x.cartId === id);
    let item = items[0];
    if(item.quantity === 1){
        deleteCart(id);
    }else{
        item.quantity -=1;
        console.log(item.quantity);
        updateLocalStorage(tblCarts,lst);
        getCartTable();
    }
}

function deleteCart(id){
  confirmMessage("Do you want to delete this blog?").then(
    function (value) {
        let lst = getCarts();

        const items = lst.filter((x)=> x.cartId === id);

        if (items.length === 0) {
          console.log('no data');
          return;
        }

        lst = lst.filter( (x) => x.cartId !== id);
        const jsonCarts = JSON.stringify(lst);
        localStorage.setItem(tblCarts, jsonCarts);

        successMessage("Deleting is successful");
        getCartTable();
    }
  );
}

function getCarts() {
  const carts = localStorage.getItem(tblCarts);
  let lst = [];
  if (carts !== null) {
    lst = JSON.parse(carts);
  }
  return lst;
}

function updateLocalStorage(key, value) {
    localStorage.setItem(key, JSON.stringify(value));
  }