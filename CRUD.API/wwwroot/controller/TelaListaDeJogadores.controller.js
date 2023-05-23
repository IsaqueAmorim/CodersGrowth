sap.ui.define([
    
	"../controller/ControllerBase",
    "../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/ui/model/json/JSONModel",
	"../repositorios/Repositorio",
 ], function (ControllerBase,formatter,Filter,FilterOperator,JSONModel,Repo) {
    "use strict";

	const enderecoController = "sap.ui.api.jogadores.controller.TelaListaDeJogadores";

    return ControllerBase.extend(enderecoController, {
        formatter : formatter,
        aoDigitar: function (oEvent) {

			const parametroQuery = "query";
			const filtrarPorNome = "nome";
			const id_TabelaJogadores = "tabela_jogadores";
			const itensDaTabela = "items";
			
			let filtro = [];
			let buscar = oEvent.getParameter(parametroQuery);
			if(buscar){
				filtro.push(new Filter(filtrarPorNome, FilterOperator.Contains, buscar));
			}

			let tabela = this.byId(id_TabelaJogadores)
			let items = tabela.getBinding(itensDaTabela);
			items.filter(filtro);
			
		},
		onInit : function(){

			const rotaHome = "home";

			this._obterDados();
			let rota = this.getOwnerComponent().getRouter();
           
            rota    
            .getRoute(rotaHome)
            .attachMatched(this._aoCoincidirRota, this);

		},
		_obterDados: async function(){
			
			const resposta = await Repo.obterTodos();
			this.getView().setModel(new JSONModel({jogadores: resposta}));

		},
		aoClicarNaLinha : function (EventoDeClique){
			this.processarEvento(()=>{

				const idLinha = "id";
				const rotaDetalhes = "detalhes";
	
				let rota = this.getOwnerComponent().getRouter();
				let idDaLinha = EventoDeClique.getSource().getBindingContext().getProperty(idLinha);
				rota.navTo(rotaDetalhes, {id: idDaLinha});
            })
	
		},
		aoClicarEmAdicionar: function(){
			this.processarEvento(()=>{

				const rotaCadastro = "cadastro";
				let rota = this.getOwnerComponent().getRouter();
				rota.navTo(rotaCadastro);
            })
		},
		_aoCoincidirRota: function(){
			this.processarEvento(()=>{

				this._obterDados();
            })
		}
    });
 });
 
