var Lista = {

    API_URL: "",
    UsuarioID: "",

    ListaVeterinarios: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;

        that.GetUsuario();
        that.BuscarVeterinarios();
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

    //Método para Recuperar todos os veterinarios
    BuscarVeterinarios: function () {
        var that = this;

        that.PreProcees();

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Veterinario/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_veterinarios = response_done;

            if (lista_veterinarios.length > 0) {

                that.ListaVeterinarios = lista_veterinarios;
                that.CreateHTMLVeterinarios();
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
        $("#table_veterinarios").addClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").removeClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#table_veterinarios").removeClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#table_veterinarios").addClass("d-none");
        $("#content_list_message").removeClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    CreateHTMLVeterinarios: function () {
        var that = this;

        if (that.ListaVeterinarios.length > 0) {

            for (var i = 0; i < that.ListaVeterinarios.length; i++) {

                var veterinario = that.ListaVeterinarios[i];


                var option_view = "<img src='../Content/icons/view.png' class='icon-action m-1' title='Visualizar'>";
                var option_edit = "<img src='..//Content/icons/edit.png' class='icon-action m-1' title='Editar'>";
                var options = option_view + option_edit;

                var element = "";
                element += "<tr>";
                element += "<td scope='col' class='text-center'>" + (parseInt(i) + 1) + "</td>";
                element += "<td scope='col' class='text-center'>" + veterinario.id + "</td>";
                element += "<td scope='col' class='text-left'>" + veterinario.nome + "</td>";
                element += "<td scope='col' class='text-left'>" + veterinario.cpf + "</td>";
                element += "<td scope='col' class='text-left'>" + veterinario.identidade + "</td>";
                element += "<td scope='col' class='text-left'>" + veterinario.registro + "</td>";
                element += "<td scope='col' class='text-left'>" + veterinario.funcionario.nome + "</td>";
                element += "<td scope='col' class='text-center'>" + options + "</td>";
                element += "</tr>";

                $("#table_veterinarios").append(element);

            }
        }
    }


}