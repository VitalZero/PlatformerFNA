using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerFNAEnvato.CharacterStates;
using PlatformerFNAEnvato.Command;
using System;

namespace PlatformerFNAEnvato
{
    public class Character : MovingObject
    {
        // variables public for states to easy access
        public float WalkSpeed { get { return 160f; } }
        public float JumpSpeed { get { return -410f; } }
        public float MinJumpSpeed { get { return 200f; } }
        public float HalfSizeX { get { return 8f; } }
        public float HalfSizeY { get { return 16f; } }
        public KeyboardState keyState;

        public enum CharacterState { Stand, Walk, Jump, GrabLedge }
        protected KeyboardState oldState;
        public CharacterState currentState = CharacterState.Stand;
        public float jumpSpeed;
        public float walkSpeed;
        public Texture2D texture;
        public SpriteEffects flip = SpriteEffects.None;

        // states are loaded on character so the machine can change to them easily
        public StandState standState;
        public JumpState jumpState;
        public WalkState walkState;
        // character state machine controller
        private IState _state;

        public void Init()
        {
            gravity = 800f;
            Aabb = new AABB(Vector2.Zero, new Vector2(HalfSizeX, HalfSizeY));
            AabbOffset.Y = Aabb.HalfSize.Y;

            jumpSpeed = JumpSpeed;
            walkSpeed = WalkSpeed;

            Scale = Vector2.One;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("mariosingle");
            _state = new JumpState();
        }

        public void Input()
        {

        }

        public void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            // queued state changes, calls onExit for outgoing state and onEnter for incoming state
            //machine.ProcessStatechanges();

            IState tmpState = _state.Update(this, (float)gameTime.ElapsedGameTime.TotalSeconds);

            if(tmpState != null)
            {
                _state.OnExit(this);

                _state = tmpState;

                _state.OnEnter(this);
            }

            UpdatePhysics(gameTime);

            if (IsOnGround && !WasOnGround)
            {
                //play sound
            }

            oldState = keyState; 
        }

        public void Draw(SpriteBatch batch)
        {
            Vector2 size = new Vector2(Aabb.HalfSize.X * 2f, Aabb.HalfSize.Y * 2f);

            batch.Draw(texture,
                            Pos,
                            null,
                            Color.White,
                            0f,
                            Aabb.HalfSize,
                            1f,
                            flip,
                            0f);
        }
    }
}
