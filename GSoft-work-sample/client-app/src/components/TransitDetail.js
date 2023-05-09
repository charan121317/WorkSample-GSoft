import '../css/transit.css';

function TransitDetail(props) {
    return (
        <div >           
            <div>
                <div
                    className="quantity"
                    style={{
                        background: `url("${props.qualityImage}")`
                    }}
                >
                    <div className="amount">
                        {props.amount}
                    </div>
                    <div className="detail">
                        Shipped Annually
                    </div>
                </div>
                <div className="cost">
                    <div className="amount">
                        {props.cost}$
                    </div>
                    <div className="detail">
                        Annual shipping cost
                    </div>
                    <div className="line"></div>
                    <div className="transit">
                        <div className="transit_image"
                            style={{
                                background: `url("${props.transitImage}")`
                            }}
                        ></div>
                        <div className="transit_text">{props.transitName}</div>
                    </div> 
                </div>
                <div
                    className="profit"
                    style={{
                        background: `url("${props.profitImage}")`
                    }}
                >
                    <div className="amount">
                        + {props.profit}%
                    </div>
                    <div className="detail">
                        Profit percentage
                    </div> 
                </div>
            </div>   
        </div>       
    );
}

export default TransitDetail;
