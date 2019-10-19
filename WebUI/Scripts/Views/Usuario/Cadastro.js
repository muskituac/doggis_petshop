var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroUsuario: new ViewModelCadastroUsuario(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#usuario_nome").focus();

        that.GetUsuario();

        //OnClick botão "Salvar"
        $("#btn_usuario_salvar").on("click", function () {
            that.SalvarUsuario();
        });

        //OnClick botão "Cancelar"
        $("#btn_usuario_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelCadastroUsuario.cadastro_usuario_id = $("#usuario_id").val();
        that.ViewModelCadastroUsuario.cadastro_usuario_nome = $("#usuario_nome").val();
        that.ViewModelCadastroUsuario.cadastro_usuario_usuario_tipo = $("#usuario_usuario_tipo").val();
        that.ViewModelCadastroUsuario.cadastro_usuario_login = $("#usuario_login").val();
        that.ViewModelCadastroUsuario.cadastro_usuario_senha = $("#usuario_senha").val();
        that.ViewModelCadastroUsuario.cadastro_usuario_ultimo_acesso = $("#usuario_ultima_alteracao").val();
        that.ViewModelCadastroUsuario.cadastro_usuario_ultima_alteracao = $("#usuario_ultima_alteracao").val();
        that.ViewModelCadastroUsuario.cadastro_usuario_responsavel = $("#usuario_responsavel").val();
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

                $("#usuario_responsavel").val(usuario.nome);

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para salvar usuario
    SalvarUsuario: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Usuario/Cadastrar",
            data: that.ViewModelCadastroUsuario,
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

        $("#message_success").removeClass("d-none");
        $("#message_fail").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#content_form_button").removeClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_success").addClass("d-none");
        $("#message_fail").removeClass("d-none");
    }


}