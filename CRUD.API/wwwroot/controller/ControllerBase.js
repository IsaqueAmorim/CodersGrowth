sap.ui.define([
    "sap/ui/core/routing/History",
], function(History) {
    
    return {
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
        }
    }
});