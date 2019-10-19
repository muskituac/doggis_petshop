var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroCliente: new ViewModelCadastroCliente(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#cliente_nome").focus();

        that.GetUsuario();

        //OnClick botão "Salvar"
        $("#btn_cliente_salvar").on("click", function () {
            that.SalvarCliente();
        });

        //OnClick botão "Cancelar"
        $("#btn_cliente_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelCadastroCliente.cadastro_cliente_id = $("#cliente_id").val();
        that.ViewModelCadastroCliente.cadastro_cliente_nome = $("#cliente_nome").val();
        that.ViewModelCadastroCliente.cadastro_cliente_identidade = $("#cliente_identidade").val();
        that.ViewModelCadastroCliente.cadastro_cliente_cpf = $("#cliente_cpf").val();
        that.ViewModelCadastroCliente.cadastro_cliente_endereco = $("#cliente_endereco").val();
        that.ViewModelCadastroCliente.cadastro_cliente_email = $("#cliente_email").val();

        if ($("#cliente_autorizacao").is(":checked") {
            that.ViewModelCadastroCliente.cadastro_cliente_autorizacao = "S";
        } else {
            that.ViewModelCadastroCliente.cadastro_cliente_autorizacao = "N";
        }

        that.ViewModelCadastroCliente.cadastro_cliente_ultima_alteracao = $("#cliente_ultima_alteracao").val();
        that.ViewModelCadastroCliente.cadastro_cliente_responsavel = $("#cliente_responsavel").val();
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

                $("#cliente_responsavel").val(usuario.nome);

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para salvar produto
    SalvarCliente: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Cliente/Cadastrar",
            data: that.ViewModelCadastroCliente,
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