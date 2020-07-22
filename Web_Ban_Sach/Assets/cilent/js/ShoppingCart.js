var cart = {
    init: function () {
        cart.loadData();
        
        cart.registerEven();
    },
    registerEven: function () {
        $("#btnAddToCart").off('click').on('click', function (e) {
            e.preventDefault();
            var BookId = parseInt($(this).data('id'));
            cart.addItem(BookId);
        });
        $(".btnDelete").off('click').on('click', function (e) {
            e.preventDefault();
            var BookId = parseInt($(this).data('id'));
            cart.deleteItem(BookId);

        });
        $(".txtQuantity").off('keyup').on('keyup', function () {
            
            var quantity = parseInt($(this).val());
            var price = parseFloat($(this).data('price'));
            var BookId = parseInt($(this).data('id'));

            var amount = quantity * price;
  
            if (isNaN(quantity) == false) {
                $("#amount_" + BookId).text(amount);
               
            }
            else {
                
                $("#amount_" + BookId).text(0);
            }
            cart.total();
        });

    },
    addItem: function (BookId) {
        $.ajax({
            url: "/ShoppingCart/Add",
            data: {
                BookId: BookId
            },
            type: 'Post',
            dataType: 'json',
            success: function (response) {
                alert("Thêm sản phẩm thành công");
            }
        });

    },
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'Get',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#tplCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {

                            BookName: item.Book.Name,
                            Imgae: item.Book.Image,

                            Price: item.Book.Price,
                            BookId: item.BookId,
                            Quantity: item.Quantity,
                            Amount: parseInt(item.Quantity) * parseInt(item.Book.Price)

                        });
                    });
                    $('#cartBody').html(html);
                    cart.total();
                    cart.registerEven();
                    
                }
            }
        });
    },
    deleteItem: function (bookId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            data: {
                BookId: bookId
            },
            type: 'Post',
            dataType: 'Json',
            success: function () {
                cart.loadData();
            }
        });
    },
    total: function () {
        var listTextBox = $('.txtQuantity');
        var total = 0;
        $.each(listTextBox, function (i, item) {
            total += parseInt($(item).val()) * parseInt($(item).data('price'));

        });
        $('#txtTongTien').text(total);
    }
}

cart.init();