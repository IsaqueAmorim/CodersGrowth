sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/m/MessageBox",
  "sap/ui/core/routing/History"
], function(Controller,JSONModel,MensagemDeTela,Historico) {
    'use strict';
    return Controller.extend("sap.ui.api.jogadores.controller.Cadastro",{
        onInit: function() {
            let JogadorModelo = new JSONModel({});
            this.getView().setModel(JogadorModelo,"jogador");
            

        },
        abrirSeletorData: function(Evento){
            this.getView().byId("MostrarSeletor").openBy(Evento.getSource().getDomRef());
        },
        aoAlterar: function(Evento){
           let data = Evento.getParameter("value")
           this.getView().byId("BotaoData").data("text", data);
        },
        aoClicarSalvar: function(Event){
           
            let json = this.criarModelo();

            fetch("https://localhost:7139/v1/jogadores",
            {method:'POST',
            headers: {"Content-Type": "application/json"},
            body:JSON.stringify(json)})
            .then(resposta => {
                if(resposta.status === 201){
                   this.mostrarCaixaDeMensagem("Cadastro.MensagemSucesso")
                   
                }
            });
        },
        mostrarCaixaDeMensagem: function(i18nMensagem){  
            let pacoteTraducoes = 
            this.getOwnerComponent()
            .getModel("i18n")
            .getResourceBundle()
            .getText(i18nMensagem);

            MensagemDeTela.success(pacoteTraducoes,{
                actions: [MensagemDeTela.Action.OK],
                onClose : () => {                 
                   this.aoClicarVoltar();
                }
            });
        },
        aoClicarVoltar: function(){
            let historico = Historico.getInstance();
            let paginaAnterior = historico.getPreviousHash();

            if(paginaAnterior == undefined){
                let rota = this.getOwnerComponent().getRouter();
                rota.navTo("home");
            }else{
               
                window.history.go(-1);
            }
        },
        criarModelo: function(){
            let modelo = this.getView().getModel("jogador").getData();
            
            let json = {
                nome : modelo.nome,
                sobrenome:modelo.sobrenome,
                apelido: modelo.apelido,
                email:modelo.email,
                elo: parseInt(modelo.elo),
                dataNascimento: modelo.dataNascimento
            }

            return json;
                 
        }
    });
});