var Entrada = {

    API_URL: "",
    UsuarioID: "",

    ViewModelEntradaEstoque: new ViewModelEntradaEstoque(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#estoque_entrada_id_produto").focus();

        that.GetUsuario();
        that.GetProdutos();

        //OnClick botão "Salvar"
        $("#btn_entrada_estoque_salvar").on("click", function () {
            that.SalvarEntradaEstoque();
        });

        //OnClick botão "Cancelar"
        $("#btn_entrada_estoque_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelEntradaEstoque.entrada_estoque_id = $("#entrada_estoque_id").val();
        that.ViewModelEntradaEstoque.entrada_estoque_id_produto = $("#entrada_estoque_id_produto").val();
        that.ViewModelEntradaEstoque.entrada_estoque_quantidade = $("#entrada_estoque_quantidade").val();
        that.ViewModelEntradaEstoque.entrada_estoque_data = $("#entrada_estoque_data").val();
        that.ViewModelEntradaEstoque.entrada_estoque_ultima_alteracao = $("#entrada_estoque_ultima_alteracao").val();
        that.ViewModelEntradaEstoque.entrada_estoque_responsavel = $("#entrada_estoque_responsavel").val();
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

            if (usuario.id != "" && usuario.id != "undefined") {

                $("#entrada_estoque_responsavel").val(usuario.nome);

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    GetProdutos: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Produto/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_produtos = response_done;

            if (lista_produtos.length > 0) {

                that.ListaProdutos = lista_produtos;
                that.CreateHTMLProdutos();
            } 
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para salvar entrada de produto no estoque
    SalvarEntradaEstoque: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Estoque/Entrada",
            data: that.ViewModelEntradaEstoque,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            if (response_done == true) {
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
        $("#content_form_button").addClass("d-none");
        $("#content_form_message").addClass("d-none");
        $("#content_form_loader").removeClass("d-none");
        $("#message_sucess").addClass("d-none");
        $("#message_fail").addClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#content_form_button").addClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_sucess").removeClass("d-none");
        $("#message_fail").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#content_form_button").removeClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_success").addClass("d-none");
        $("#message_fail").removeClass("d-none");
    },

    CreateHTMLProdutos: function () {
        var that = this;

        if (that.ListaProdutos.length > 0) {

            for (var i = 0; i < that.ListaProdutos.length; i++) {

                var produto = that.ListaProdutos[i];

                var element = "";
                element += "<option value='"+produto.id+"'>" + produto.nome + "</option>";

                $("#entrada_estoque_id_produto").append(element);

            }
        }
    }


}