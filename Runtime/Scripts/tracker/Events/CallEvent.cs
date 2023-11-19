using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Esta clase se agregar� a cualquier gameobject que vaya a llamar a un evento.
/// En caso de necesitar par�metros adicionales, en el propio inspector se indicar�n seg�n el tipo de evento que vaya a enviarse desde aqu�.
/// 
/// </summary>

namespace GURHelper
{
    public class CallEvent : MonoBehaviour
    {
        [SerializeField]
        eventType TYPE = eventType.NULL;

        public void TrackEvent()
        {
            switch (TYPE)
            {
                #region BASIC EVENTS
                // Casos para eventos b�sicos
                case eventType.SESSION_START:
                    // C�digo para SESSION_START
                    break;

                case eventType.SESSION_END:
                    // C�digo para SESSION_END
                    break;

                case eventType.TEST_START:
                    // C�digo para TEST_START
                    break;

                case eventType.TEST_END:
                    // C�digo para TEST_END
                    break;

                case eventType.LEVEL_START:
                    // C�digo para LEVEL_START
                    break;

                case eventType.LEVEL_END:
                    // C�digo para LEVEL_END
                    break;

                case eventType.PAUSE:
                    // C�digo para PAUSE
                    break;

                case eventType.UNPAUSE:
                    // C�digo para UNPAUSE
                    break;

                #endregion

                #region DIFFICULTY_DEATHS
                // Casos para eventos relacionados con la dificultad y la muerte
                case eventType.DEATH:
                    // C�digo para DEATH
                    Tracker.Instance.TrackSynchroEvent(Tracker.Instance.Death()
                                                        .X(transform.position.x)
                                                        .Y(transform.position.y)
                                                        .Z(transform.position.z));
                    break;

                case eventType.PLAYER_POSITION:
                    // C�digo para PLAYER_POSITION
                    break;
                #endregion

                case eventType.NULL:
                    // C�digo para NULL
                    break;

                // Manejo de otros casos no especificados
                default:
                    Debug.LogWarning("Caso no manejado: " + TYPE);
                    break;
            }
        }
    }

}

