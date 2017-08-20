﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    public class Card
    {
        private static long serialVersionUID = 1L;
        private String name;
        private int playFatigueValue;
        private String imgFilePath;
        private String cardBackImgPath;

        /**
         * Constructor for the Card class.
         * @param name card's name
         * @param fatigueValue Fatigue Value for the card
         * @param imgFilePath File path that points to the card image
         */
        public Card(String name, int fatigueValue, String imgFilePath)
        {
            this.name = name;
            this.playFatigueValue = fatigueValue;
            this.imgFilePath = imgFilePath;

            setCardBackImgPath("CardImages//CardBack.png");
        }

        public Card()
        {
            // TODO Auto-generated constructor stub
        }

        /**
         * overridden equals method that compares two cards. If the two cards have the same name, and fatigue value
         * they are considered to be equal.
         */
        public override bool Equals(Object obj)
        {
            if (obj is Card) {
                Card cardToCheck = (Card)obj;
                if (cardToCheck.getName().Equals(name) && cardToCheck.getPlayFatigueValue() == playFatigueValue)
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * @return the file path that points to the card image
         */
        public String getImgFilePath()
        {
            // TODO Auto-generated method stub
            return imgFilePath;
        }

        /**
         * @return the cards name
         */
        public String getName()
        {
            return name;
        }

        /**
         * @return the play fatigue value
         */
        public int getPlayFatigueValue()
        {
            return playFatigueValue;
        }

        ///**
        // * returns an ImageIcon that has been reduced by the decimal value provided. The method calls the getReducedSizeImage method and passes it the
        // * reducePercent and imageIcon.
        // * @param reducePercent how reduced the image will be
        // * @param imageIcon the imageIcon you want to reduce
        // * @return the newly reduced imageIcon
        // */
        //public static ImageIcon getReducedSizeImageIcon(double reducePercent, ImageIcon imageIcon)
        //{
        //    Image reducedImage = getReducedSizeImage(reducePercent, imageIcon.getImage());
        //    imageIcon.setImage(reducedImage);
        //    return imageIcon;
        //}

        ///**
        // * method will reduce this cards image by the provided percent.
        // * @param reducePercent how reduced the image should be
        // * @return newly reduced image
        // * @throws ImageNotFoundException
        // */
        //public Image getReducedCardImage(double reducePercent)
        //{
        //    return getReducedSizeImage(reducePercent, getImage());
        //}

        ///**
        // * Reads the image file path and creates an Image object.
        // * @return the Image object created from the file path
        // * @throws ImageNotFoundException
        // */
        //public Image getImage()
        //{
        //    try {
        //        return ImageIO.read(new File(imgFilePath));
        //    } catch (IOException e) {
        //        throw new ImageNotFoundException(imgFilePath, LocalDateTime.now());
        //    }
        //}

        /**
         * @param imgFilePath newly set image file path
         */
        public void setImageFilePath(String imgFilePath)
        {
            this.imgFilePath = imgFilePath;
        }

        ///**
        // * reduces an image by the reduction percent provided. Uses the getScaledInstance within the Image class.
        // * @param reductionPercent how reduced
        // * @param imgToReduce image to reduce
        // * @return
        // */
        //public static Image getReducedSizeImage(double reductionPercent, Image imgToReduce)
        //{
        //    int imgHight = imgToReduce.getHeight(null);
        //    int imgWidth = imgToReduce.getWidth(null);

        //    Double reducedHightDouble = (imgHight * reductionPercent);
        //    Double reducedWidthDouble = (imgWidth * reductionPercent);

        //    int reducedHightAsInt = reducedHightDouble.intValue();
        //    int reducedWidthAsInt = reducedWidthDouble.intValue();

        //    return imgToReduce.getScaledInstance(reducedWidthAsInt, reducedHightAsInt, 0);

        //}

        /**
         * @return the cardBackImgPath
         */
        public String getCardBackImgPath()
        {
            return cardBackImgPath;
        }

        /**
         * @param cardBackImgPath the cardBackImgPath to set
         */
        public void setCardBackImgPath(String cardBackImgPath)
        {
            this.cardBackImgPath = cardBackImgPath;
        }

        //  /**
        //* Reads the card back file path and creates an Image object to be returned
        //* @return the Image object created from the file path
        //* @throws ImageNotFoundException
        //*/
        //  public Image getCardBackImage()
        //  {
        //try {
        //          return ImageIO.read(new File(cardBackImgPath));
        //      } catch (IOException e) {
        //          throw new ImageNotFoundException(cardBackImgPath, LocalDateTime.now());
        //      }
        //  }
    }
}
