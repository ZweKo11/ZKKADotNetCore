const tblProducts = "Products";
let productId = null;

getProductTable();
// createProduct();
function readProduct() {
  let lst = getProducts();
}
//create product
function createProduct(name, price) {
  let lst = getProducts();
  const requestModel = {
    id: uuidv4(),
    name: name,
    price: price,
  };
  lst.push(requestModel);
  const jsonProduct = JSON.stringify(lst);
  localStorage.setItem(tblProducts, jsonProduct);

  successMessage("Saving is successful!");
  clearControls();
}

//create product
$("#btnCreate").click(function () {
  console.log("hello");
  let name = $("#txtName").val();
  let price = $("#price").val();

  if (productId === null) {
    createProduct(name, price);
  }else{
    updateProduct(productId, name, price);
    productId = null;
  }
  getProductTable();
});

//read product
function getProductTable() {
  let lst = getProducts();
  let count = 0;
  let htmlRows = "";

  lst.forEach((item) => {
    let htmlRow = `
              <tr>
                  <td>${++count}</td>
                  <td>${item.name}</td>
                  <td>${item.price}Ks</td>
                  <td>
                      <button type="button" class="btn btn-light" onclick="editProduct('${item.id}')"><i class="fa-solid fa-pen-to-square text-success"></i></button>
                      <button type="button" class="btn btn-light" onclick="deleteProduct('${item.id}')"><i class="fa-solid fa-trash-can text-danger"></i></button>
                  </td>
                  <td>
                      <button type="button" class="btn btn-warning text-danger" onclick="addToCart('${item.id}')"><i class="fa-solid fa-cart-plus"></i></button>
                  </td>
              </tr>
          `;
    htmlRows += htmlRow;
  });

  $("#tbody").html(htmlRows);
}

function editProduct(id) {
  let lst = getProducts();

  const items = lst.filter((x) => x.id === id);

  if (items.length === 0) {
    console.log("No data Found!");
    errorMessage("No data found");
    return;
  }

  let item = items[0];
  productId = item.id;
  $("#txtName").val(item.name);
  $("#price").val(item.price);

  $("#txtName").focus();
}

function updateProduct(id, name, price) {
  let lst = getProducts();

  const items = lst.filter((x) => x.id === id);
  console.log(items);
  console.log(items.length);

  if (items.length === 0) {
    console.log("No data Found!");
    return;
  }

  const item = items[0];
  (item.name = name), (item.price = price);

  const index = lst.findIndex((x) => x.id === id);
  lst[index] = item;

  const jsonProduct = JSON.stringify(lst);
  localStorage.setItem(tblProducts, jsonProduct);
  successMessage("Updating successful");
}

function deleteProduct(id) {
  confirmMessage("Do you want to delete this blog?").then(
      function (value) {
          let lst = getProducts();

          const items = lst.filter((x) => x.id === id);

          if (items.length === 0) {
            console.log("No data Found!");
            return;
          }

          lst = lst.filter((x) => x.id !== id);
          const jsonProduct = JSON.stringify(lst);
          localStorage.setItem(tblProducts, jsonProduct);

          successMessage("Deleting is successful");
          getProductTable();
      }
    );
}

function getProducts() {
  const products = localStorage.getItem(tblProducts);
    // console.log(products);

  let lst = [];
  if (products !== null) {
    lst = JSON.parse(products);
  }
  return lst;
}

function clearControls() {
  $("#txtName").val("");
  $("#price").val("");

  $("#txtName").focus();
}
