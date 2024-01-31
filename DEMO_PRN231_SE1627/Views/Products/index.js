<script>
    console.log("Hello world");
    
    const updateProduct = () => {
        event.preventDefault();
    /*        const data = new FormData(document.querySelector('form'));*/
    const data = {
        productName: productName.value,
    unitPrice: parseFloat(unitPrice.value),
    unitsInStock: parseInt(unitsInStock.value),
    image: image.value,
    categoryId: parseInt(category.value)
        };

    const config = {
        method: "PUT",
    headers: {
        'Content-Type': 'application/json'
            },
    body: JSON.stringify(data)
        }

    fetch("http://localhost:5091/api/Product/" + productId.value, config)
            .then(res => {
        console.log(res)
                if (res.ok) {
                    return res.json()
                }
    else {
                    throw new Error("Error in updateProduct")
                }
            })
            .then(res => {
                const tableRow = document.getElementById(productId.value)
    tableRow.dataset.productName = productName.value;
    tableRow.dataset.unitPrice = unitPrice.value;
    tableRow.dataset.unitsInStock = unitsInStock.value;
    tableRow.dataset.image = image.value;
    tableRow.dataset.categoryId = category.value;

    tableRow.querySelector('.productName').innerHTML = productName.value;
    tableRow.querySelector('.unitPrice').innerHTML = parseFloat(unitPrice.value).toFixed(2);
    tableRow.querySelector('.unitsInStock').innerHTML = unitsInStock.value;
    tableRow.querySelector('.image').innerHTML = image.value;
    tableRow.querySelector('.category').innerHTML = category.options[category.selectedIndex].text;

            })
    }


    const deleteProduct = (id) => {
        event.preventDefault();
    if (confirm("Are you sure delete this product!!")) {

            const url = "http://localhost:5091/api/Product/" + id

    const config = {
        method: "DELETE",
    header: {
        'Content-Type': 'application/json'
                }
            }
    fetch(url, config)
                .then(res => {
                    if (res.ok) {
                        return true
                    }
    else {
                        throw new Error("Error in deleteProduct")
                    }
                })
                .then(success => {
                    if (success) {
                        var tr = document.getElementById(id)
    console.log(tr)
    tr.remove();
                    }
    else {
        console.log("Id not exist when delete");
                    }
                })
        }
    }

    const addProduct = () => {
        event.preventDefault();

    const url = "http://localhost:5091/api/Product"

    const data = {

        productName: productName.value,
    unitPrice: parseFloat(unitPrice.value),
    unitsInStock: parseInt(unitsInStock.value),
    image: image.value,
    categoryId: parseInt(category.value)
        };

    const config = {
        method: "POST",
    headers: {
        'Content-Type': 'application/json'
            },
    body: JSON.stringify(data)
        }

    fetch(url, config)
            .then(res => {
                if (res.ok) {
                    return res.json();
                }
    else {
                    throw new Error("Error in addProduct")
                }
            })
            .then(data => {
                const categoryName = document.getElementById("category").querySelector(`option[value = "${data.categoryId}"]`).innerHTML

    var tr = `<tr id="${data.productId}" data-product-id="${productId}"
        data-unit-price="${data.productName}"
        data-units-in-stock="${data.unitsInStock}"
        data-image="${data.image}"
        data-category-id="${data.categoryId}">
        <td>
            <a href="" onclick="getProduct(${data.productId})">
                ${data.productId}
            </a>
        </td>
        <td class="productName">
            ${data.productName}
        </td>
        <td class="unitPrice">
            ${parseFloat(data.unitPrice).toFixed(2)}
        </td>
        <td class="unitsInStock">
            ${data.unitsInStock}
        </td>
        <td class="image">
            ${data.image}
        </td>
        <td class="category">
            ${categoryName}
        </td>
        <td>
            @* <a href='../Products/Delete?id=@item.ProductId'>Delete</a> *@
            <a href="" onclick="deleteProduct(${data.productId})">Delete</a>
        </td>

    </tr>`
    var tbody = document.getElementById("tbody")
    tbody.innerHTML += tr;
            })
    }
</script>


//@* Cach dung jquery * @
//    @* <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script> * @
//    @* <script>
//        const getProduct = (id) => {
//            event.preventDefault();
//        $.ajax({
//            url: '/Products/GetProduct',
//        type: 'GET',
//        data: {id: id },
//        success: function (data) {
//            console.log(data);
//        $('#productId').val(data.productId);
//        $('#productName').val(data.productName);
//        $('#unitPrice').val(data.unitPrice);
//        $('#unitsInStock').val(data.unitsInStock);
//        $('#image').val(data.image);
//        $('#category').val(data.categoryId);
//                }
//            });
//        }
//    </script> * @

//    @* Cach dung XMLHttpRequest * @
//        @* <script>
//        const getProduct = (id) => {
//                event.preventDefault();
//            var http = new XMLHttpRequest();
//            http.open("GET", "/Products/GetProduct?id=" + id, true);
//            http.send();
//            http.onreadystatechange = function () {
//                if (this.readyState == 4 && this.status == 200) {
//                console.log(this.responseText);
//            var data = JSON.parse(this.responseText);
//            console.log(data);
//            productId.value = data.productId;
//            productName.value = data.productName;
//            document.getElementById("unitPrice").value = data.unitPrice;
//            document.getElementById("unitsInStock").value = data.unitsInStock;
//            document.getElementById("image").value = data.image;
//            document.getElementById("category").value = data.categoryId;
//                }
//            }
//        }
//        </script> * @

//        @* Cach dung data atribite * @
//            @* <script>
//        const getProduct = (id) => {
//                    event.preventDefault();

//                var tr = document.getElementById(id);
//                var data = {
//                    productId: tr.dataset.productId,
//                productName: tr.dataset.productName,
//                unitPrice: tr.dataset.unitPrice,
//                unitsInStock: tr.dataset.unitsInStock,
//                image: tr.dataset.image,
//                categoryId: tr.dataset.categoryId
//            };

//                document.getElementById("productId").value = data.productId;
//                document.getElementById("productName").value = data.productName;
//                document.getElementById("unitPrice").value = data.unitPrice;
//                document.getElementById("unitsInStock").value = data.unitsInStock;
//                document.getElementById("image").value = data.image;
//                document.getElementById("category").value = data.categoryId;
//        }
//            </script> * @

//            @* Cach dung fetch * @
< script >
    const getProduct = (id) => {
    event.preventDefault();
    fetch("http://localhost:5091/api/Product/" + id)
        .then(res => {
            if (res.ok) {
                return res.json();
            }
            else {
                throw new Error("Error");
            }
        })
        .then(data => {
            productId.value = data.productId;
            productName.value = data.productName;
            document.getElementById("unitPrice").value = data.unitPrice;
            document.getElementById("unitsInStock").value = data.unitsInStock;
            document.getElementById("image").value = data.image;
            document.getElementById("category").value = data.categoryId;
        })
}
</script >