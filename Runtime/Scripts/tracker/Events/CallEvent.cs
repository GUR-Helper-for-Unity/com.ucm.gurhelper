using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Esta clase se agregará a cualquier gameobject que vaya a llamar a un evento.
/// En caso de necesitar parámetros adicionales, en el propio inspector se indicarán según el tipo de evento que vaya a enviarse desde aquí.
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
                // Casos para eventos básicos
                case eventType.SESSION_START:
                    // Código para SESSION_START
                    break;

                case eventType.SESSION_END:
                    // Código para SESSION_END
                    break;

                case eventType.TEST_START:
                    // Código para TEST_START
                    break;

                case eventType.TEST_END:
                    // Código para TEST_END
                    break;

                case eventType.LEVEL_START:
                    // Código para LEVEL_START
                    break;

                case eventType.LEVEL_END:
                    // Código para LEVEL_END
                    break;

                case eventType.PAUSE:
                    // Código para PAUSE
                    break;

                case eventType.UNPAUSE:
                    // Código para UNPAUSE
                    break;

                #endregion

                #region DIFFICULTY_DEATHS
                // Casos para eventos relacionados con la dificultad y la muerte
                case eventType.DEATH:
                    // Código para DEATH
                    Tracker.Instance.TrackSynchroEvent(Tracker.Instance.Death()
                                                        .X(transform.position.x)
                                                        .Y(transform.position.y)
                                                        .Z(transform.position.z));
                    break;

                case eventType.PLAYER_POSITION:
                    // Código para PLAYER_POSITION
                    break;
                #endregion

                case eventType.NULL:
                    // Código para NULL
                    break;

                // Manejo de otros casos no especificados
                default:
                    Debug.LogWarning("Caso no manejado: " + TYPE);
                    break;
            }
        }
    }

}

