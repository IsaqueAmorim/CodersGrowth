/* ================================================
============ SERVIÇO DE VALIDAÇÕES ===============*/
sap.ui.define([], function() {
    'use strict';
    
    return {
        validaEmail: function(email){

            const regex = /\S+@\S+\.\S+/;
        
            if(email.length === 0){
                return false
            }
            else if(regex.test(email)){
                return false
            }

            return true;
        },
        validaCamposDeTexto: function(texto){
        
            const regex = new RegExp("^[a-zA-Z\u00C0-\u017F´]+$")
            if(texto.length === 0){
               return false;
            }else if(regex.test(texto)){
                return false;
            }
            return true;
        },
        validaElo(elo){
            const regex = new RegExp('^[0-8]+$');

            if(regex.test(elo)){
                return false;
            }
            return true;
        },
        validaDataNascimento(data){  
            let dataConvertida = new Date(data)
            if(dataConvertida != "Invalid Date" && dataConvertida < new Date()) {
                return false;
            }
            return true;
        }
    }
});
