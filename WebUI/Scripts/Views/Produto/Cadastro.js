var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroProduto: new ViewModelCadastroProduto(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#produto_nome").focus();

        that.GetUsuario();

        //OnClick botão "Salvar"
        $("#btn_produto_salvar").on("click", function () {
            that.SalvarProduto();
        });

        //OnClick botão "Cancelar"
        $("#btn_produto_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelCadastroProduto.cadastro_produto_id = $("#produto_id").val();
        that.ViewModelCadastroProduto.cadastro_produto_nome = $("#produto_nome").val();
        that.ViewModelCadastroProduto.cadastro_produto_fabricante = $("#produto_fabricante").val();
        that.ViewModelCadastroProduto.cadastro_produto_especificacoes = $("#produto_especificacoes").val();
        that.ViewModelCadastroProduto.cadastro_produto_valor_atual = $("#produto_valor_atual").val();
        that.ViewModelCadastroProduto.cadastro_produto_pataz_bonus = $("#produto_pataz_bonus").val();
        that.ViewModelCadastroProduto.cadastro_produto_pataz_custo = $("#produto_pataz_custo").val();
        that.ViewModelCadastroProduto.cadastro_produto_ultima_alteracao = $("#produto_ultima_alteracao").val();
        that.ViewModelCadastroProduto.cadastro_produto_responsavel = $("#produto_responsavel").val();
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

                $("#produto_responsavel").val(usuario.nome);

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para salvar produto
    SalvarProduto: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Produto/Cadastrar",
            data: that.ViewModelCadastroProduto,
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
    },

    PosProcessFail: function () {
        $("#content_form_button").removeClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_fail").removeClass("d-none");
    }


}