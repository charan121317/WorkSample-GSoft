import React, { useState, useEffect } from 'react';
import Header from './Header';
import TransitDetail from './TransitDetail';

import TruckQuality from '../assets/truck-quantity-background.png';
import TruckProfit from '../assets/truck-profit-background.png';
import TruckImage from '../assets/truck.png'

import PlaneQuality from '../assets/plane-quantity-background.png';
import PlaneProfit from '../assets/plane-profit-background.png';
import PlaneImage from '../assets/plane.png'

import TrainQuality from '../assets/train-quantity-background.png';
import TrainProfit from '../assets/train-profit-background.png';
import TrainImage from '../assets/train.png'

import BoatQuality from '../assets/boat-quantity-background.png';
import BoatProfit from '../assets/boat-profit-background.png';
import BoatImage from '../assets/boat.png'


function Container() {
  const [selectedOption, setSelectedOption] = useState();
  const [qualityImage, setQualityImage] = useState();
  const [transitImage, setTransitImage] = useState();
  const [profitImage, setProfitImage] = useState();
  const [optimalTransport, setOptimalTransport] = useState([]);

  useEffect(() => {
    if(selectedOption && selectedOption !== 'Select') 
    {
        async function fetchTransitData(){
            let response = await fetch(`http://localhost:5285/Product/${selectedOption}/transit`)
            response = await response.json()
            setOptimalTransport(response)
        }
        fetchTransitData(); 
    }
  }, [selectedOption]);


  useEffect(() => {
    if(optimalTransport.transitName)
    {
        if(optimalTransport.transitName === 'Truck')
        {
            setQualityImage(TruckQuality);
            setTransitImage(TruckImage);
            setProfitImage(TruckProfit);
        }
        if(optimalTransport.transitName === 'Train')
        {
            setQualityImage(TrainQuality);
            setTransitImage(TrainImage);
            setProfitImage(TrainProfit);
        } 
        if(optimalTransport.transitName === 'Plane')
        {
            setQualityImage(PlaneQuality);
            setTransitImage(PlaneImage);
            setProfitImage(PlaneProfit);
        } 
        if(optimalTransport.transitName === 'Boat')
        {
            setQualityImage(BoatQuality);
            setTransitImage(BoatImage);
            setProfitImage(BoatProfit);
        }  
       
    }
  }, [optimalTransport]);

  return (
    <div>
        <div>
          <Header callback={setSelectedOption}/>            
        </div>           
        <div>
          {selectedOption !== 'Select' &&
            <TransitDetail
                cost = {optimalTransport.annualCost}
                amount = {optimalTransport.annualQuantity}
                profit = {optimalTransport.profitPercentage} 
                qualityImage = {qualityImage}     
                transitImage = {transitImage}
                profitImage = {profitImage}
                transitName = {optimalTransport.transitName}            
            ></ TransitDetail>
          }
        </div>            
    </div>        
  );
}

export default Container;
