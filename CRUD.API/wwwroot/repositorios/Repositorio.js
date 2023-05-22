sap.ui.define([], function() {
    'use strict';

    const baseUrl = "https://localhost:7139/v1/jogadores/"

    const sucessoOk = 200;
    const sucessoSemConteudo = 204;
    const sucessoCriado = 201;
   
    
    
    return {
        obterTodos: async function() {

            const config = {
                method:'GET',
                headers: {"Content-Type": "application/json"}
            }

           
                const jogadores = await fetch(baseUrl,config).then((resposta) => {

                    if(resposta.status === sucessoOk ){
            
                        return resposta.json();

                    }else{

                        throw resposta.status;
                    }
                });
             
            return jogadores;
            
        },
        obterPorId: async function(id){

            const config = {
                method:'GET',
                headers: {"Content-Type": "application/json"},
            }

            const jogador = await fetch(baseUrl+id,config).then((resposta) => {

                if(resposta.status === sucessoOk ){
        
                    return resposta.json();

                }else{

                    throw resposta.status;
                }
            });
            return jogador;
        
           
        },
        criar: async function(jogador){

            const config = {
                method:'POST',
                headers: {"Content-Type": "application/json"},
                body:JSON.stringify(jogador)
            }

            
            const resposta = fetch(baseUrl,config).then(async (resposta) => {
                if(resposta.status === sucessoCriado ){
        
                    return resposta.status;

                }else{

                    throw resposta.status;
                }
            
            });
            return resposta;
        },
        deletar: function(id){

            const config = {
                method:'DELETE',
                headers: {"Content-Type": "application/json"},
                
            }

            const resposta = fetch(baseUrl+id,config).then(resposta => {

                if(resposta.status === sucessoSemConteudo){
        
                    return resposta.status;

                }else{

                    throw resposta.statusText;
                }
            }) 
            return resposta;
        },
        atualizar: async function(jogadorAtualizado,id){

            const config = {
                method:'PUT',
                headers: {"Content-Type": "application/json"},
                body:JSON.stringify(jogadorAtualizado)
            }

            const resposta = await fetch(baseUrl+id,config).then(resposta => {

                if(resposta.status ===  sucessoSemConteudo){
        
                    return resposta.status;

                }else{

                    throw resposta.statusText;
                }
            }) 

            return resposta;
        }
    }
});