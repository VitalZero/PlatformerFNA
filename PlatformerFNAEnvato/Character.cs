using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerFNAEnvato.CharacterStates;
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
        public float MaxFallingSpeed { get { return 900f; } }
        public KeyboardState keyState;

        public enum CharacterState { Stand, Walk, Jump, GrabLedge }
        protected KeyboardState oldState;
        public CharacterState currentState = CharacterState.Stand;
        public float jumpSpeed;
        public float walkSpeed;
        public readonly float gravity = 800f;
        public Texture2D texture;
        public SpriteEffects flip = SpriteEffects.None;

        // states are loaded on character so the machine can change to them easily
        public StandState standState;
        public JumpState jumpState;
        public WalkState walkState;
        // character state machine controller
        public StateMachine machine;

        public void Init()
        {
            Aabb = new AABB(Vector2.Zero, new Vector2(HalfSizeX, HalfSizeY));
            AabbOffset.Y = Aabb.HalfSize.Y;

            jumpSpeed = JumpSpeed;
            walkSpeed = WalkSpeed;

            Scale = Vector2.One;

            machine = new StateMachine();

            standState = new StandState(this);
            jumpState = new JumpState(this);
            walkState = new WalkState(this);

            machine.ChangeState(standState);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("mariosingle");
        }

        public void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            // queued state changes, calls onExit for outgoing state and onEnter for incoming state
            machine.ProcessStatechanges();


            machine.GetCurrentState().Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            // Update moving object physics after state controller
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

            machine.GetCurrentState().Draw(batch);
        }
    }
}
