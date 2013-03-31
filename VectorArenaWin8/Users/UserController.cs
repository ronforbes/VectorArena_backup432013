using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorArenaCore.Ships;
using VectorArenaWin8.Networking;

namespace VectorArenaWin8.Users
{
    class UserController
    {
        User user;

        Dictionary<Keys, Ship.Action> keyMappings;

        KeyboardState previousKeyboardState;

        ClientNetworkManager networkManager;

        List<UserCommand> commands;
        
        public UserController(User user, ClientNetworkManager networkManager)
        {
            this.user = user;
            this.networkManager = networkManager;

            keyMappings = new Dictionary<Keys, Ship.Action>();

            previousKeyboardState = Keyboard.GetState();

            commands = new List<UserCommand>();
        }

        public void Initialize()
        {
            keyMappings.Clear();

            keyMappings.Add(Keys.Left, Ship.Action.TurnLeft);
            keyMappings.Add(Keys.Right, Ship.Action.TurnRight);
            keyMappings.Add(Keys.Up, Ship.Action.ThrustForward);
            keyMappings.Add(Keys.Down, Ship.Action.ThrustBackward);
            keyMappings.Add(Keys.Space, Ship.Action.Fire);
        }

        public void Update(TimeSpan elapsedTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            // Handle key presses and releases
            foreach (KeyValuePair<Keys, Ship.Action> keyMapping in keyMappings)
            {
                if (keyboardState.IsKeyDown(keyMapping.Key) && previousKeyboardState.IsKeyUp(keyMapping.Key))
                {
                    UserCommand userCommand = new UserCommand(keyMapping.Value, true, elapsedTime);
                    commands.Add(userCommand);
                    networkManager.StartAction(keyMapping.Value.ToString(), userCommand.Id);
                    user.Ship.Actions[keyMapping.Value] = true;
                }

                if (keyboardState.IsKeyUp(keyMapping.Key) && previousKeyboardState.IsKeyDown(keyMapping.Key))
                {
                    UserCommand userCommand = new UserCommand(keyMapping.Value, false, elapsedTime);
                    commands.Add(userCommand);
                    networkManager.StopAction(keyMapping.Value.ToString(), userCommand.Id);
                    user.Ship.Actions[keyMapping.Value] = false;
                }
            }

            previousKeyboardState = keyboardState;
        }

        public void ReplayCommands(int latestCommandId)
        {
            for (int command = latestCommandId; command < commands.Count(); command++)
            {
                user.Ship.Actions[commands[command].Action] = commands[command].Active;
                user.Ship.Update(commands[command].ElapsedTime);
            }
        }
    }
}
