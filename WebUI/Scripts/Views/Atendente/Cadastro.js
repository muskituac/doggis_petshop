var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroAtendente: new ViewModelCadastroAtendente(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#atendente_nome").focus();

        that.GetFuncionarios();

        //OnClick botão "Salvar"
        $("#btn_atendente_salvar").on("click", function () {
            that.SalvarAtendente();
        });

        //OnClick botão "Cancelar"
        $("#btn_atendente_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelCadastroAtendente.cadastro_atendente_id = $("#atendente_id").val();
        that.ViewModelCadastroAtendente.cadastro_atendente_id_funcionario = $("#atendente_id_funcionario").val();
        that.ViewModelCadastroAtendente.cadastro_atendente_nome = $("#atendente_nome").val();
    },

    //Método para buscar todos os funcionarios
    GetFuncionarios: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Funcionario/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var funcionarios = response_done;

            if (funcionarios != "" && funcionarios != "undefined" && funcionarios != null) {

                for (var i = 0; i < funcionarios.length; i++) {

                    var funcionario = funcionarios[i];
                    $("#atendente_id_funcionario").append("<option value='" + funcionario.id + "'>" + funcionario.nome + "</option>");

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
    SalvarAtendente: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Atendente/Cadastrar",
            data: that.ViewModelCadastroAtendente,
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
        $("#message_success").addClass("d-none");
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