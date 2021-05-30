using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTAS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // BUGS //
        // Audios do Boss -> Provavelmente ta mudando tao rapido o audio que ele buga 100% ou chamando o audio tao rapido q ele buga...
        // -> NOVA POSSIBILIDADE, QD LEVANTA ESCUDO FAZ MTS PEDIDOS SEGUIDOS OQ FAZ COM Q TODOS SEJAM CHAMADOS AO FIM DA ANIMACAO DO BAIXAR
        // solucao seria 1 audio source por ataque, mas paia e ia fica td 1 por cima do outro
        // Animacao de morte do Mago -> Provavelmente "mata" duas vezes e chama o trigger de morte duas vezes  FIXED



        // BOSS //

        //Entrada -> Cutscene com ele falando / HUD OFF / Focada no BOSS  -> DONE

        // Primeira fase -> Ataca com bastão e levanta a mão -> Flechas -> DONE

        // Segunda fase -> Primeira fase + rápidae Levantar escudo -> Estacas de madeira (C escudo n pode tomar dano) -> DONE
        // Mudar a cor do sprite do boss -> DONE

        // Terceira fase -> Spawnar um inimigo ranged quando levanta escudo  -> DONE

        // Morte -> Animação Victory do player com menu para voltar -> DONE

        // Player //

        //  Adicionar condição para poder usar magia ... -> DONE
        // ... Condição -> Matar um mago na fase dos inimigos e pegar o item que dropará dele  -> DONE
        // no mago if(player não tem item) {dropa item} -> DONE
        // no player if(player n tem item) {n usa magia} // DONE

        // FASES //

        // Fase 0 -> Menu -> DONE
        // Fase 2 -> Explicação da missão pelo Alfredo -> DONE
        // Fase 3 -> Teste de inimigos -> DONE
        // Fase 4 -> Boss -> DONE

        // Transições & Sons

        // Fase 0 -> DONE
        // Fase 2 -> DONE
        // Fase 3 -> DONE
        // Fase 4 -> DONE

        // Fogo tem que ter som de fogo  -> DONE
        // Animação do fogo explodindo quando tocar em um objeto  -> DONE

        // Ataques do boss precisam de som  -> DONE (meio quebrado -> muito na real)
        // Boss precisa de voz  -> DONE


        //  MENU //

        // Fazer tela inicial que levará ao play e as opções de som -> DONE
        // Adicionar icon do jogo (na barra de tarefas vai ser o icon do player) -> DONE 
        // 

        // EXTRAS //
        // Potion de healing +10 de vida on collision DONE
        // Adicionar menu de Pause DONE
        // Adicionar sprites de fogo no Mage  DONE


    }


}
