using PoliticalSimulatorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PoliticalSimulatorCore.Controller {
    class GameController {

        #region Constants

        private const int MAX_HAND_SIZE = 5;
        private const int MAX_FIELD_SIZE = 5;
        private const int START_HEALTH = 10;
        private const int CARDS_AT_START = 3;
        private const int WIN_CREDIT_AWARD = 5;
        private static Random RNG = new Random();

        #endregion

        #region Fields

        private int turn;

        #endregion

        #region Properties

        public List<Player> Players { get; set; }

        public Player CurrentPlayer {
            get {
                return Players[turn % Players.Count];
            }
        }

        #endregion

        #region Constructor

        public GameController(params Player[] players) {

            // Error: no players passed.
            if (players == null || players.Length == 0) {
                throw new ArgumentNullException("players");
            }

            // Add the passed players into the controller's list of players.
            Players = players.ToList();

            // Set the turn.
            turn = 0;

            // Allow all players to draw the predefined amount of cards at the start of the game.
            foreach (Player player in Players) {
                for (int i = 0; i < CARDS_AT_START; i++) {
                    Draw(player);
                }
            }
        }

        #endregion

        #region Gameplay Methods

        public void EndTurn() {
            Player player = CurrentPlayer;
            Draw(player);
            player.PlayerFatigue.Increment();
            turn++;
        }

        public static bool Draw(Player player) {
            if (player.Profile.CurrentDeck.IsEmpty()) {
                return false;
            } else if (player.Hand.Count >= MAX_HAND_SIZE) {
                return false;
            } else {
                player.Hand.Add(player.Profile.CurrentDeck.getTopCard());
                CheckForJack(player.Hand);
                return true;
            }
        }

        public static bool PlayCard(Player player, Creature card, int fieldLocation) {
            if (!InHand(player.Hand, card)) {
                return false;
            }

            if (SpaceOnField(player.Field)) {
                if (player.PlayerFatigue.UseFatigue(card.PlayFatigueValue)) {
                    player.Hand.Remove(card);
                    player.Field[fieldLocation] = card;
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public static bool PlayCard(Player player, Enhancement enhancement, Field field, int fieldLocation) {
            if (!InHand(player.Hand, enhancement)) {
                return false;
            }

            if(player.PlayerFatigue.TooFatigued(enhancement.PlayFatigueValue)) {
                return false;
            }

            if (CardAtLocation(field, fieldLocation)) {

                if (field[fieldLocation] is IEnhanceable) {
                    Creature creatureToModify = field[fieldLocation];

                    switch (enhancement.getStat()) {
                        case Enhancement.ATTACK:
                            creatureToModify.AttackValue += enhancement.getModValue();
                            break;
                        case Enhancement.HEALTH:
                            creatureToModify.HealthValue += enhancement.getModValue();
                            break;
                        case Enhancement.FATIGUE:
                            if ((creatureToModify.AttackFatigueValue + enhancement.getModValue()) > 0) {
                                creatureToModify.AttackFatigueValue += enhancement.getModValue();
                            } else {
                                return false;
                            }
                            break;
                        case Enhancement.CHANCE_TO_ATTACK:
                            creatureToModify.ChanceToHit += enhancement.getModValue();
                            break;
                    }

                    player.PlayerFatigue.UseFatigue(enhancement.PlayFatigueValue);
                    player.Hand.Remove(enhancement);
                    return true;

                }else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public static bool Attack(Player player, Creature attackingCreature, Field field, int fieldLocation) {
            if (CardAtLocation(field, fieldLocation)) {
                if (player.PlayerFatigue.UseFatigue(attackingCreature.AttackFatigueValue)) {
                    if (AttackMissed(attackingCreature.ChanceToHit)) {
                        return true;
                    } else {
                        Creature creatureAttacked = field[fieldLocation];

                        // Apply damage to attacked card
                        int attackValue = attackingCreature.AttackValue + attackingCreature.CreatureType.applyModifier(creatureAttacked.CreatureType);
                        creatureAttacked.HealthValue -= attackValue;

                        // Check if the creature died
                        if (creatureAttacked.HealthValue <= 0) {
                            //The creature is dead therefore it is removed from its location
                            field.Remove(creatureAttacked);
                            return true;
                        } else {
                            return true;
                        }
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public static bool Attack(Player player, Creature attackingCreature, Player playerToAttack) {
            if (playerToAttack.Field.Count > 0) {
                return false;
            } else {
                if (player.PlayerFatigue.UseFatigue(attackingCreature.AttackFatigueValue)) {
                    if (AttackMissed(attackingCreature.ChanceToHit)) {
                        return true;
                    } else {
                        playerToAttack.Health -= attackingCreature.AttackValue;
                        return true;
                    }

                } else {
                    return false;
                }
            }
        }

        #endregion

        #region Private Methods

        private static bool AttackMissed(int chanceToHit) {
            return chanceToHit < RNG.Next(100);
        }

        private static void CheckForJack(Hand hand) {
            HashSet<int> jackSet = new HashSet<int>();
            foreach (Card card in hand) {
                if (card is JackCard) {
                    JackCard jackCard = card as JackCard;
                    jackSet.Add(jackCard.PieceNumber);
                }
            }
            if (jackSet.Count == 5) {
                CombineJack(hand);
            }
        }

        private static void CombineJack(Hand hand) {
            using (var handEnumerator = hand.GetEnumerator()) {
                do {
                    if (handEnumerator.Current is JackCard) {
                        hand.Remove(handEnumerator.Current);
                    }
                } while (handEnumerator.MoveNext());

                hand.Add(JackCard.JackMyers);
            }
        }

        private static bool SpaceOnField(Field field) {
            return field.Count < MAX_FIELD_SIZE;
        }

        private static bool InHand(Hand hand, Card card) {
            return hand.Contains(card);
        }

        private static bool CardAtLocation(Field field, int fieldLocation) {
            return field[fieldLocation] is Creature;
        }

        #endregion

        #region Just Don't Look at This Mess

        /**
         * Apply an action with the two given position selections. 
         * Depending on the locations, the action could include attack, or play.
         * @param label_position_sideSelectionOne The first position selection
         * @param label_position_sideSelectionTwo The second position selection
         * @return The message concatenated from all applied actions
 
        public String applyAction(String[] label_position_sideSelectionOne, String[] label_position_sideSelectionTwo) {
            int position = Integer.parseInt(label_position_sideSelectionTwo[1]);
            Card actionCard;
            switch (label_position_sideSelectionOne[0]) {
                case "field":
                    actionCard = getCreatureAtPosition(CurrentPlayer().getPlayerSide(),
                                                        Integer.parseInt(label_position_sideSelectionOne[1]));
                    if (label_position_sideSelectionTwo[0].equals("player")) {
                        // Attack the Player
                        String message = (CurrentPlayer().attack((Creature)actionCard, getOpposingPlayer()));
                        if (getOpposingPlayer().getHealthPoints() <= 0) {
                            GameOver();
                            return "";
                        }
                        return message;
                    } else {
                        int opponentsSide = getOpposingPlayer().getPlayerSide();
                        int attackingCardPosition = Integer.parseInt(label_position_sideSelectionOne[1]);
                        Creature creatureToAttack = getCreatureAtPosition(opponentsSide, position);
                        // Attack the Creature
                        String message = (CurrentPlayer().attack((Creature)actionCard, opponentsSide, position, Player.WITH_FATIGUE));
                        if (message.equals(Player.FATIGUED)) {
                            // No attack
                        } else {
                            if (!message.equals(Player.ATTACK_MISSED)) {
                                message += ((Creature)actionCard).getType().modifierString(creatureToAttack.getType());
                            }
                            // Creature attacks back
                            String attackBackMessage = (getOpposingPlayer().attack(creatureToAttack, CurrentPlayer().getPlayerSide(), attackingCardPosition, Player.NO_FATIGUE));
                            if (!attackBackMessage.equals(Player.ATTACK_MISSED)) {
                                attackBackMessage += (creatureToAttack).getType().modifierString(((Creature)actionCard).getType());
                            }
                            message += attackBackMessage;
                        }
                        return message;
                    }
                case "hand":
                    actionCard = CurrentPlayer().getHandOfCards().get(Integer.parseInt(label_position_sideSelectionOne[1]));
                    if ((getCurrentPlayerTurn() == 1 && label_position_sideSelectionTwo[2].equals("north")) ||
                        getCurrentPlayerTurn() == 2 && label_position_sideSelectionTwo[2].equals("south")) {
                        //Enhance opposing player's card
                        return (CurrentPlayer().playCard(actionCard, getOpposingPlayer().getPlayerSide(), position));
                    } else {
                        // Play the Card or enhance own card
                        return (CurrentPlayer().playCard(actionCard, CurrentPlayer().getPlayerSide(), position));
                    }
            }
            return "error";
        }

        */

        /**
         * Update stats for the winning and losing player. 
         * Add credits to winning Player, and reload the Players' Deck.
         */
        private void GameOver() {
            // Update Stats
            //UserProfile winningPlayer = CurrentPlayer().getProfile();
            //UserProfile losingPlayer = getOpposingPlayer().getProfile();
            //winningPlayer.addWin();
            //winningPlayer.addCredits(WIN_CREDIT_AWARD);
            //losingPlayer.addLoss();
            // Reload Decks
            //reloadDecks();
            return;
        }

        #endregion

    }
}
