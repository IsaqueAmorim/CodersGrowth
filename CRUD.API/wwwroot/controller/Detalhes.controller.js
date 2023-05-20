sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History",
    "sap/m/MessageBox",
    "../repositorios/Repositorio"
    
], function(Controller, Formatador,JSONModel,Historico,MessageBox,Repo) {
    'use strict';

    const urlBase = "https://localhost:7139/v1/jogadores/";
    // ========= ROTAS ============
    const rotaDetalhes = "detalhes";
    const rotaEdicao = "edicao";
    const rotaHome = "home";

    // ========= MENSAGENS DE TELA ===========
    const i18n_mensagemDeletado = "Detalhes.Mensagem.Sucesso.Deletar";
    const i18n_mensagemConfirmarDeletar = "Detalhes.Mensagem.Confirmar.Remover";
    const i18n_mensagemFalahaDeletar = "Detalhes.Mensagem.Erro.Deletar";

    // ========= CAMPOS ==========
    const campoId = "campoId";

    // ====== CÓDIGOS DE RESPOSTA ======
    const codigoOK = 200;
    const codigoNoContent = 204;
    const codigoFalhaNaRequisicao = 400;
    
    return Controller.extend("sap.ui.api.jogadores.controller.Detalhes",{

        formatter: Formatador,
        onInit: function() {
            var rota = this.getOwnerComponent().getRouter();
            rota.getRoute(rotaDetalhes).attachMatched(this.aoCoincidirRota, this);
        },
        aoCoincidirRota: function (evento) {
            
            var id = evento.getParameter("arguments").id;
            this.obterDados(id);
        },
        obterDados: async function(id){

            const resposta = await Repo.obterPorId(id);
		    this.getView().setModel(new JSONModel({jogador: resposta}));
		},
        aoClicarVoltar: function(){
            let historico = Historico.getInstance();
            let paginaAnterior = historico.getPreviousHash();

            if(paginaAnterior == undefined){
                let rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaHome);
            }else{
               
                window.history.go(-1);
            }
        },
        aoClicarEditar: function (){
 
            let rota = this.getOwnerComponent().getRouter();
            let idJogador = this.getView().byId(campoId).getValue();
			rota.navTo(rotaEdicao, {id: idJogador});
        },
        aoClicarDeletar: function (){

            this.mostrarCaixaDeMensagem(
                i18n_mensagemConfirmarDeletar,
                [MessageBox.Action.YES,MessageBox.Action.NO],
                MessageBox.warning
            )
        
        },
        mostrarCaixaDeMensagem: async function(i18nMensagem,Acao,TipoMensagem){ 
            
            let rota = this.getOwnerComponent().getRouter();
            let idJogador = this.getView().byId(campoId).getValue();
            
            TipoMensagem(this.obterTraducao(i18nMensagem),{
                actions: Acao,
                
                onClose :async  (acao) => {     

                    if(acao === MessageBox.Action.YES){

                        const resposta = await Repo.deletar(idJogador)

                        if(resposta == codigoOK){

                            MessageBox.success(this.obterTraducao(i18n_mensagemDeletado),{
                                actions: [MessageBox.Action.OK],
                                onClose: function(){
                                   rota.navTo(rotaHome)
                                }
                            })

                        }else{
                            MessageBox.error(this.obterTraducao(i18n_mensagemFalahaDeletar),{
                                actions: [MessageBox.Action.OK],
                                onClose: function(){
                                   
                                }
                            })
                        }       
                    }
                }   
            })                        
        },
        obterTraducao: function(i18nMensagem){
            let pacoteTraducoes = 
            this.getOwnerComponent()
            .getModel("i18n")
            .getResourceBundle()
            .getText(i18nMensagem);

            return pacoteTraducoes;

            

        }
    })
});