using PoliticalSimulatorCore.Model.Game_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model {
    class PlayerController {

        #region Constants

        private const int MAX_HAND_SIZE = 5;
        private const int MAX_FIELD_SIZE = 5;
        private const int START_HEALTH = 10;

        #endregion

        #region Properties

        public UserProfile Profile { get; set; }

        public Fatigue PlayerFatigue { get; set; }

        public List<Creature> Field { get; set; }

        public List<Card> Hand { get; set; }

        public int Health { get; set; }

        #endregion

        public PlayerController(UserProfile profile) {
            Profile = profile;
            PlayerFatigue = new Fatigue();
            Field = new List<Creature>(MAX_FIELD_SIZE);
            Hand = new List<Card>(MAX_HAND_SIZE);
            Health = START_HEALTH;
        }


        #region Gameplay Methods

        public bool draw() {
            if (Profile.CurrentDeck.IsEmpty()) {
                return false;
            } else if (Hand.Count >= MAX_HAND_SIZE) {
                return false;
            } else {
                Hand.Add(Profile.CurrentDeck.getTopCard());
                CheckForJack();
                return true;
            }
        }

        #endregion

        #region Private Methods

        private void CheckForJack() {
            HashSet<int> jackSet = new HashSet<int>();
            foreach (Card card in Hand) {
                if (card is JackCard) {
                    JackCard jackCard = card as JackCard;
                    jackSet.Add(jackCard.PieceNumber);
                }
            }
            if (jackSet.Count == 5) {
                combineJack();
            }
        }

        private void combineJack() {
            using (var handEnumerator = Hand.GetEnumerator()) {
                do {
                    if (handEnumerator.Current is JackCard) {
                        Hand.Remove(handEnumerator.Current);
                    }
                } while (handEnumerator.MoveNext());

                Hand.Add(JackCard.JackMyers);
            }
        }

        #endregion


        public String playCard(Card card, Integer playerNumber, Integer fieldLocation) {
        if (!hasInHand(card)) {
            return CARD_NOT_IN_HAND;
        } else if (!canPlay(card)) {
            return FATIGUED;
        } else {
            if (card instanceof Creature) {
                if (hasSpaceOnField()) {
                    handOfCards.remove(card);
                    field.get(playerNumber).put(fieldLocation, (Creature)card);
                    fatigueForCurrentTurn += card.getPlayFatigueValue();
                    return CARD_PLAYED;
                } else {
                    return NO_SPACE_ERROR;
                }
            }else if (card instanceof Enhancement) {
                if (isCardAtLocation(playerNumber, fieldLocation)) {
                    if (field.get(playerNumber).get(fieldLocation) instanceof Enhanceable) {
                        String message = applySpell((Enhancement)card, field.get(playerNumber).get(fieldLocation));
                        if (!message.equals(FATIGUE_BOUNDS_ERROR)) {
                            handOfCards.remove(card);
                            fatigueForCurrentTurn += card.getPlayFatigueValue();
                        }
                        return message;
                    }else {
                        return NOT_RARE;
                    }
                } else {
                    return NO_CARD_AT_LOCATION_ERROR;
                }
            }
            return "";
        }
    }

    /**
	 * Use the given Creature to attack the given position. Apply fatigue if specified.
	 * @param attackingCard The Creature attacking
	 * @param playerSide The Player's side of the field to attack
	 * @param fieldLocation The location on the field to attack
	 * @param takesFatigue True to apply fatigue, false if not
	 * @return message
	 */
    public String attack(Creature attackingCard, Integer playerSide, Integer fieldLocation, boolean takesFatigue) {
        if (isCardAtLocation(playerSide, fieldLocation)) {
            if (takesFatigue && !canAttack(attackingCard)) {
                return FATIGUED;
            }
            if (takesFatigue) {
                fatigueForCurrentTurn += attackingCard.getAttackFatigueValue();
            }
            if (attackMissed(attackingCard)) {
                return ATTACK_MISSED;
            } else {
                Creature creatureToBeAttacked = field.get(playerSide).get(fieldLocation);
                // Apply damage to attacked card
                int attackValue = attackingCard.getAttackValue() + attackingCard.getType().applyModifier(creatureToBeAttacked.getType());
                creatureToBeAttacked.setHealthValue(creatureToBeAttacked.getHealthValue() - attackValue);
                // Check if creatures died
                if (creatureToBeAttacked.getHealthValue() <= 0) {
                    //The creature is dead therefore is removed from its location
                    field.get(playerSide).remove(fieldLocation);
                    return creatureToBeAttacked.getName() + " was killed\n";
                } else {
                    return creatureToBeAttacked.getName() + " was attacked for " + attackValue + "\n";
                }
            }
        } else {
            return NO_CARD_AT_LOCATION_ERROR;
        }
    }

    /**
	 * Use the given Creature to attack the given Player.
	 * @param attackingCard The Creature attacking
	 * @param playerToAttack The Player to attack
	 * @return message
	 */
    public String attack(Creature attackingCard, PlayerController playerToAttack) {
        if (!canAttack(attackingCard)) {
            return FATIGUED;
        }
        if (field.get(playerToAttack.getPlayerSide()).size() > 0) {
            return CREATURES_ON_FIELD;
        } else {
            fatigueForCurrentTurn += attackingCard.getAttackFatigueValue();
            if (attackMissed(attackingCard)) {
                return ATTACK_MISSED;
            } else {
                playerToAttack.setHealthPoints(playerToAttack.getHealthPoints() - attackingCard.getAttackValue());
                return playerToAttack.getProfile().getName() + " attacked for " + attackingCard.getAttackValue() + "\n";
            }
        }
    }

    /**
	 * Determine if the Player has enough fatigue for the Creature to attack 
	 * @param attackingCard Creature to check fatigue
	 * @return true if Creature can attack, false if not
	 */
    private boolean canAttack(Creature attackingCard) {
        if ((attackingCard.getAttackFatigueValue() + fatigueForCurrentTurn) <= maxFatigueForCurrentTurn) {
            return true;
        } else {
            return false;
        }
    }

    /**
	 * Increment the Player's max fatigue by 1, stop if 10 is reached. Reset the
	 * fatigue for the current turn.
	 */
    protected void incrementFatigue() {
        if (maxFatigueForCurrentTurn < 10) {
            maxFatigueForCurrentTurn++;
        }
        fatigueForCurrentTurn = 0;
    }

    /**
	 * Determine if the attacking Creature successfully attacked.
	 * @param attackingCard The Creature to determine successful attack
	 * @return true if attack hit, false if not
	 */
    private boolean attackMissed(Creature attackingCard) {
        return attackingCard.getChanceToHit() < RNG.nextInt(100);
    }

    /**
	 * Determine if the Card is in the Player's hand
	 * @param card Card to search for
	 * @return true if Card is in hand, false if not
	 */
    private boolean hasInHand(Card card) {
        if (handOfCards.contains(card)) {
            return true;
        } else {
            return false;
        }
    }

    /**
	 * Determine if there is free space on the field
	 * @return true if there is space, false if not
	 */
    protected boolean hasSpaceOnField() {
        if (field.get(playerSide).size() < MAX_FIELD_SIZE) {
            return true;

        } else {
            return false;
        }
    }

    /**
	 * Determine if the Card can be played with the current fatigue
	 * @param card Card to determine if can be played
	 * @return true if CArd can be played, false if not
	 */
    protected boolean canPlay(Card card) {
        if ((card.getPlayFatigueValue() + fatigueForCurrentTurn) <= maxFatigueForCurrentTurn) {
            return true;
        } else {
            return false;
        }
    }

    /**
	 * Apply the given Enhancement to the given Creature
	 * @param enhancement The Enhancement to use
	 * @param creatureToModify The Creature to get enhanced
	 * @return message
	 */
    private String applySpell(Enhancement enhancement, Creature creatureToModify) {
        switch (enhancement.getStat()) {
            case Enhancement.ATTACK:
                creatureToModify.setAttackValue(creatureToModify.getAttackValue() + enhancement.getModValue());
                break;
            case Enhancement.HEALTH:
                creatureToModify.setHealthValue(creatureToModify.getHealthValue() + enhancement.getModValue());
                break;
            case Enhancement.FATIGUE:
                if (creatureToModify.getAttackFatigueValue() + enhancement.getModValue() > 0)
                    creatureToModify.setAttackFatigueValue(creatureToModify.getAttackFatigueValue() + enhancement.getModValue());
                else
                    return FATIGUE_BOUNDS_ERROR;
                break;
            case Enhancement.CHANCE_TO_ATTACK:
                creatureToModify.setChanceToHit(creatureToModify.getChanceToHit() + enhancement.getModValue());
                break;
        }
        return creatureToModify.getName() + "'s " + enhancement.getStat() + " was modified by " + enhancement.getModValue() + "\n";
        //		if(enhancement.getStat().equals("Attack")){
        //			creatureToModify.setAttackValue(enhancement.getModValue());
        //		} else {
        //			creatureToModify.setHealthValue(enhancement.getModValue());
        //		}
        //		return creatureToModify.getName() + "'s " + enhancement.getStat() + " was modified by " + enhancement.getModValue();
    }

    /**
	 * Determine if a Card is at the given field location
	 * @param playerSide Player's side of field to search
	 * @param fieldLocation Position on field's side
	 * @return true if Card is at location, false if not
	 */
    private boolean isCardAtLocation(int playerSide, int fieldLocation) {
        return field.get(playerSide).containsKey(fieldLocation);
    }

    /**
	 * @return Player's side of the field
	 */
    public Integer getPlayerSide() {
        return playerSide;
    }

    /**
	 * @return Player's String representation of the side of the field ("north" or "south")
	 */
    public String getPlayerStringSide() {
        if (playerSide == 1) return "south";
        else return "north";
    }

    /**
	 * @return Opposing player's side of the field
	 */
    public Integer getOpposingPlayerSide() {
        if (playerSide == 1) return 2;
        else return 1;
    }

    /**
	 * @return Opposing player's String representation of the side of the field ("north" or "south")
	 */
    public String getOpposingPlayerStringSide() {
        if (playerSide == 1) return "north";
        else return "south";
    }

    /**
	 * @param healthPoints Number to set Player's health points
	 */
    public void setHealthPoints(int healthPoints) {
        this.healthPoints = healthPoints;
    }

    /**
	 * @return Player's health points
	 */
    public int getHealthPoints() {
        return healthPoints;
    }

    /**
	 * @return Player's hand
	 */
    public ArrayList<Card> getHandOfCards() {
        return handOfCards;
    }

    /**
	 * Determine if a Creature is on the field
	 * @return true if there is a Creature on the field, false if not
	 */
    public boolean creatureOnField() {
        if (field.get(playerSide).isEmpty()) {
            return false;
        } else {
            return true;
        }
    }

    /**
	 * @return Maximum hand size
	 */
    public static int getMAX_HAND_SIZE() {
        return MAX_HAND_SIZE;
    }

    /**
	 * @return Maximum field size
	 */
    public static int getMAX_FIELD_SIZE() {
        return MAX_FIELD_SIZE;
    }

    /**
	 * @return Player's profile
	 */
    public UserProfile getProfile() {
        return profile;
    }

    /**
	 * @return Player's fatigue
	 */
    public int getFatigue() {
        return maxFatigueForCurrentTurn - fatigueForCurrentTurn;
    }

    /**
	 * @return Player's image file path
	 */
    public String getImgFilePath() {
        return imgFilePath;
    }

    /**
	 * @param imgFilePath the imgFilePath to set
	 */
    public void setImgFilePath(String imgFilePath) {
        this.imgFilePath = imgFilePath;
    }

    /**
	 * 
	 * @return The Image located at the imgFilePath
	 */
    public Image getImage() {
        try {
            return ImageIO.read(new File(imgFilePath));
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }

    //	//If drawing is going to be an option to the player
    //	public String draw2(){
    //		if(handOfCards.size() <= MAX_HAND_SIZE && deck.getSize() > 0 && fatigueForCurrentTurn > 0){
    //			handOfCards.add(deck.getTopCard());
    //			return "";
    //		} else if (handOfCards.size() > MAX_HAND_SIZE){
    //			return HAND_TOO_FULL;
    //		} else {
    //			return EMPTY_DECK;
    //		}
    //	}

}
}
