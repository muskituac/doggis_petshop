var Lista = {

    API_URL: "",
    UsuarioID: "",

    ListaPromocoes: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;

        that.GetUsuario();
        that.BuscarPromocoes();
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

    //Método para Recuperar todos as promocoes
    BuscarPromocoes: function () {
        var that = this;

        that.PreProcees();

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Promocao/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_promocoes = response_done;

            if (lista_promocoes.length > 0) {

                that.ListaPromocoes = lista_promocoes;
                that.CreateHTMLPromocoes();
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
        $("#table_promocoes").addClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").removeClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#table_promocoes").removeClass("d-none");
        $("#content_list_message").addClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#table_promocoes").addClass("d-none");
        $("#content_list_message").removeClass("d-none");
        $("#content_list_loader").addClass("d-none");
    },

    CreateHTMLPromocoes: function () {
        var that = this;

        if (that.ListaPromocoes.length > 0) {

            for (var i = 0; i < that.ListaPromocoes.length; i++) {

                var promocao = that.ListaPromocoes[i];


                var option_view = "<img src='../Content/icons/view.png' class='icon-action m-1' title='Visualizar'>";
                var option_edit = "<img src='..//Content/icons/edit.png' class='icon-action m-1' title='Editar'>";
                var options = option_view + option_edit;

                var element = "";
                element += "<tr>";
                element += "<td scope='col' class='text-center'>" + (parseInt(i) + 1) + "</td>";
                element += "<td scope='col' class='text-center'>" + promocao.id + "</td>";
                element += "<td scope='col' class='text-left'>" + promocao.descricao + "</td>";
                element += "<td scope='col' class='text-left'>" + promocao.porcentagem + "</td>";
                element += "<td scope='col' class='text-left'>" + promocao.data_inicio + "</td>";
                element += "<td scope='col' class='text-left'>" + promocao.data_termino + "</td>";
                element += "<td scope='col' class='text-center'>" + options + "</td>";
                element += "</tr>";

                $("#table_promocoes").append(element);

            }
        }
    }


}