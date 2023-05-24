sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/m/MessageBox",
], function(Controller,History,MessageBox) {
    
     const enderecoController = "sap.ui.api.jogadores.controller.ControllerBase";
    return Controller.extend( enderecoController,{
        navegarParaHome: function(rota) {

            const rotaHome = "home"
            rota.navTo(rotaHome);
            
        },
        navegarParaPaginaAnterior: function(rota) {
            const rotaHome = "home";

            let historico = History.getInstance();
            let paginaAnterior = historico.getPreviousHash();

            if(paginaAnterior == undefined){
                rota.navTo(rotaHome);
            }else{
               const paginaAnterior = -1;
                window.history.go(paginaAnterior);
            }
        },
        obterTraducao: function (i18nMensagem) {
            const arquivoI18n = "i18n"

            return this.getOwnerComponent()
            .getModel(arquivoI18n)
            .getResourceBundle()
            .getText(i18nMensagem);
        },
        processarEvento: function(action){
            const tipoDaPromise = "catch",
                tipoBuscado = "function";
              try {
                      var promise = action();
                      if(promise && typeof(promise[tipoDaPromise]) == tipoBuscado){
                              promise.catch(error => MessageBox.error(error.message));
                      }
              } catch (error) {
                      MessageBox.error(error.message);
              }
        }

    })
});