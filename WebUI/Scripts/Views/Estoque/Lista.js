var Lista = {

    API_URL: "",
    UsuarioID: "",

    ListaEntradasEstoque: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;

        that.GetUsuario();
        that.BuscarEntradas();
    },

    //Método para buscar usuario logado
    GetUsuario: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Usuario/GetUsuario?usuario_id=" + that.UsuarioID,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var usuario = response_done;

            if (usuario.id == "" || usuario.id == "undefined") {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para Recuperar todos os produtos
    BuscarEntradas: function () {
        var that = this;

        that.PreProcees();

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Estoque/GetAllEntradas",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_entrada_estoque = response_done;

            if (lista_entrada_estoque.length > 0) {

                that.ListaEntradasEstoque = lista_entrada_estoque;
                that.CreateHTMLProdutos();
                that.PosProcessSuccess();

            } else {
                that.PosProcessFail();
            }

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            that.PosProcessFail();

        });

    },

    PreProcees: function () {
        $("#table_entradas").addClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").removeClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#table_entradas").removeClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#table_produtos").addClass("d-none");
        $("#content_list_message").removeClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    CreateHTMLProdutos: function () {
        var that = this;

        if (that.ListaEntradasEstoque.length > 0) {

            for (var i = 0; i < that.ListaEntradasEstoque.length; i++) {

                var entrada_estoque = that.ListaEntradasEstoque[i];


                var option_view = "<img src='../Content/icons/view.png' class='icon-action m-1' title='Visualizar'>";
                var option_edit = "<img src='..//Content/icons/edit.png' class='icon-action m-1' title='Editar'>";
                var options = option_view + option_edit;

                var element = "";
                element += "<tr>";
                element += "<td scope='col' class='text-center'>" + (parseInt(i) + 1) + "</td>";
                element += "<td scope='col' class='text-center'>" + entrada_estoque.id + "</td>";
                element += "<td scope='col' class='text-left'>" + entrada_estoque.produto.nome + "</td>";
                element += "<td scope='col' class='text-right'>" + entrada_estoque.quantidade + "</td>";
                element += "<td scope='col' class='text-center'>" + entrada_estoque.data + "</td>";
                element += "<td scope='col' class='text-center'>" + options + "</td>";
                element += "</tr>";

                $("#table_entradas").append(element);

            }
        }
    }


}