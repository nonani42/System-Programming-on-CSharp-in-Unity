﻿using Mirror;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Multiplayer
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class Character : NetworkBehaviour
    {
        protected Action OnUpdateAction { get; set; }
        protected abstract FireAction fireAction { get; set; }

        [SyncVar] protected Vector3 serverPosition;

        protected virtual void Initiate()
        {
            //OnUpdateAction += Movement;
        }

        private void Update()
        {
            //OnUpdate();
        }

        private void OnUpdate()
        {
            //OnUpdateAction?.Invoke();
        }

        [Command]
        protected void CmdUpdatePosition(Vector3 position)
        {
            //serverPosition = position;
        }

        public abstract void Movement();
    }
}
