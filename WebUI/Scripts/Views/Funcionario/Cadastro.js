var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroFuncionario: new ViewModelCadastroFuncionario(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#funcionario_nome").focus();

        that.GetUsuarios();

        //OnClick botão "Salvar"
        $("#btn_funcionario_salvar").on("click", function () {
            that.SalvarFuncionario();
        });

        //OnClick botão "Cancelar"
        $("#btn_funcionario_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelCadastroFuncionario.cadastro_funcionario_id = $("#funcionario_id").val();
        that.ViewModelCadastroFuncionario.cadastro_funcionario_nome = $("#funcionario_nome").val();
        that.ViewModelCadastroFuncionario.cadastro_funcionario_id_usuario = $("#funcionario_id_usuario").val();
    },

    //Método para buscar todos os usuários
    GetUsuarios: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Usuario/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var usuarios = response_done;

            if (usuarios != "" && usuarios != "undefined" && usuarios != null) {

                for (var i = 0; i < usuarios.length; i++) {

                    var usuario = usuarios[i];
                    $("#funcionario_id_usuario").append("<option value='" + usuario.id + "'>" + usuario.nome + "</option>");

                }

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para salvar produto
    SalvarFuncionario: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Funcionario/Cadastrar",
            data: that.ViewModelCadastroFuncionario,
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

        $("#message_sucess").addClass("d-none");
        $("#message_fail").removeClass("d-none");
    }


}