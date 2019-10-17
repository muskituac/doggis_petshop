var Lista = {

    API_URL: "",
    UsuarioID: "",

    ListaAgendamentos: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;

        that.GetUsuario();
        that.BuscarAgendamentos();
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

    //Método para Recuperar todos os agendamentos
    BuscarAgendamentos: function () {
        var that = this;

        that.PreProcees();

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Agendamento/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_agendamentos = response_done;

            if (lista_agendamentos.length > 0) {

                that.ListaAgendamentos = lista_agendamentos;
                that.CreateHTMLAgendamentos();
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
        $("#table_agendamentos").addClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").removeClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#table_agendamentos").removeClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#table_agendamentos").addClass("d-none");
        $("#content_list_message").removeClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    CreateHTMLAgendamentos: function () {
        var that = this;

        if (that.ListaAgendamentos.length > 0) {

            for (var i = 0; i < that.ListaAgendamentos.length; i++) {

                var agendamento = that.ListaAgendamentos[i];


                var option_view = "<img src='../Content/icons/view.png' class='icon-action m-1' title='Visualizar'>";
                var option_edit = "<img src='..//Content/icons/edit.png' class='icon-action m-1' title='Editar'>";
                var options = option_view + option_edit;

                var element = "";
                element += "<tr>";
                element += "<td scope='col' class='text-center'>" + (parseInt(i) + 1) + "</td>";
                element += "<td scope='col' class='text-center'>" + agendamento.id + "</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.cliente.nome + "</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.pet.nome + " (" + agendamento.pet.pet_tipo.descricao + ")</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.servico.nome + "</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.funcionario.nome + "</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.data_inicio_br + "</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.data_termino_br + "</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.notificacao_enviada + "</td>";
                element += "<td scope='col' class='text-left'>" + agendamento.cancelamento + "</td>";
                element += "<td scope='col' class='text-center'>" + options + "</td>";
                element += "</tr>";

                $("#table_agendamentos").append(element);

            }
        }
    }


}