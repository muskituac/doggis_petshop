var Index = {

    API_URL: "",

    ViewModelLogin: new ViewModelLogin(),

    Initialize: function (api_url) {
        var that = this;

        that.API_URL = api_url;


        $("#login_usuario").focus();

        //OnClick botão "Login"
        $("#btn_entrar").on("click", function () {
            that.Login();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelLogin.LoginUsuario = $("#login_usuario").val();
        that.ViewModelLogin.LoginSenha = $("#login_senha").val();
    },

    //Método para realizar login
    Login: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Login/Login",
            data: that.ViewModelLogin,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var usuario = response_done;

            if (usuario.id != "" && usuario.id != "undefined") {
                window.location = "Home/Index?usuario_id=" + usuario.id;
            } else {
                $("#alert_error").removeClass("d-none");
            }

            that.PosProcess();

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            $("#alert_error").removeClass("d-none");
        });

    },

    PreProcees: function () {
        $("#btn_entrar").addClass("d-none");
        $("#form_loader").removeClass("d-none");
        $("#alert_error").addClass("d-none");
    },

    PosProcess: function () {
        $("#form_loader").addClass("d-none");
        $("#btn_entrar").removeClass("d-none");
    }


}