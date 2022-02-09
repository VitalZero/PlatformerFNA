using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PlatformerFNAEnvato
{
    public class Character : MovingObject
    {
        public float WalkSpeed { get { return 160f; } }
        public float JumpSpeed { get { return -410f; } }
        public float MinJumpSpeed { get { return 200f; } }
        public float HalfSizeX { get { return 8f; } }
        public float HalfSizeY { get { return 16f; } }
        public float MaxFallingSpeed { get { return 900f; } }

        public enum CharacterState { Stand, Walk, Jump, GrabLedge }
        protected KeyboardState oldState;
        private CharacterState currentState = CharacterState.Stand;
        private float jumpSpeed;
        private float walkSpeed;
        private const float gravity = 800f;
        private Texture2D texture;
        SpriteEffects flip = SpriteEffects.None;

        public void Init()
        {
            Aabb = new AABB(Vector2.Zero, new Vector2(HalfSizeX, HalfSizeY));
            AabbOffset.Y = Aabb.HalfSize.Y;

            jumpSpeed = JumpSpeed;
            walkSpeed = WalkSpeed;

            Scale = Vector2.One;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("mariosingle");
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            switch(currentState)
            {
                case CharacterState.Stand:
                    {
                        Speed = Vector2.Zero;
                        //animationPlayer.Play("stand");
                        if (!IsOnGround)
                        {
                            currentState = CharacterState.Jump;
                            break;
                        }

                        if (keyState.IsKeyDown(Keys.Right) != keyState.IsKeyDown(Keys.Left))
                        {
                            currentState = CharacterState.Walk;
                            break;
                        }
                        else if(keyState.IsKeyDown(Keys.Space))
                        {
                            Speed.Y = jumpSpeed;
                            currentState = CharacterState.Jump;
                            break;
                        }
                    }

                    break;

                case CharacterState.Walk:
                    {
                        //animationPlayer.Play("walk");
                        if (keyState.IsKeyDown(Keys.Right) == keyState.IsKeyDown(Keys.Left))
                        {
                            currentState = CharacterState.Stand;
                            Speed = Vector2.Zero;
                        }
                        else if(keyState.IsKeyDown(Keys.Right))
                        {
                            if(PushingRightWall)
                            {
                                Speed.X = 0f;
                            }
                            else
                            {
                                Speed.X = walkSpeed;
                            }

                            Scale.X = -Math.Abs(Scale.X);
                            flip = SpriteEffects.None;
                        }
                        else if(keyState.IsKeyDown(Keys.Left))
                        {
                            if(PushingLeftWall)
                            {
                                Speed.X = 0f;
                            }
                            else
                            {
                                Speed.X = -walkSpeed;
                            }

                            Scale.X = Math.Abs(Scale.X);
                            flip = SpriteEffects.FlipHorizontally;
                        }

                        if (keyState.IsKeyDown(Keys.Space))
                        {
                            Speed.Y = jumpSpeed;
                            //sound.Play();
                            currentState = CharacterState.Jump;
                            break;
                        }
                        else if(!IsOnGround)
                        {
                            currentState = CharacterState.Jump;
                            break;
                        }
                    }
                    break;

                case CharacterState.Jump:
                    { 
                        //animationPlayer.Play("jump")
                        Speed.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        Speed.Y = Math.Min(Speed.Y, MaxFallingSpeed);

                        if (keyState.IsKeyDown(Keys.Right) == keyState.IsKeyDown(Keys.Left))
                        {
                            Speed.X = 0f;
                        }
                        else if (keyState.IsKeyDown(Keys.Right))
                        {
                            if (PushingRightWall)
                            {
                                Speed.X = 0f;
                            }
                            else
                            {
                                Speed.X = walkSpeed;
                            }

                            Scale.X = Math.Abs(Scale.X);
                        }
                        else if (keyState.IsKeyDown(Keys.Left))
                        {
                            if (PushingLeftWall)
                            {
                                Speed.X = 0f;
                            }
                            else
                            {
                                Speed.X = -walkSpeed;
                            }
                        }

                        //if (!keyState.IsKeyDown(Keys.Space) && Speed.Y > 0f)
                        //{
                        //    Speed.Y = Math.Min(Speed.Y, 200);
                        //}


                        if (IsOnGround)
                        {
                            if (keyState.IsKeyDown(Keys.Right) == keyState.IsKeyDown(Keys.Left))
                            {
                                currentState = CharacterState.Stand;
                                Speed = Vector2.Zero;
                            }
                            else
                            {
                                currentState = CharacterState.Stand;
                                Speed.Y = 0f;
                            }
                        }
                    }

                    break;

                case CharacterState.GrabLedge:
                    break;
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
                0f);//new Rectangle((int)Pos.X, (int)Pos.Y, (int)size.X, (int)size.Y), Color.Red);
        }
    }
}
