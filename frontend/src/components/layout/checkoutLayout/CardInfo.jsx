function CardInfo({ cardInfo, setCardInfo }) {
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setCardInfo(prev => ({ ...prev, [name]: value }));
    };

    return (
        <>
            <div className="mb-3">
                <label className="form-label">Card Number</label>
                <input
                    type="text"
                    className="form-control"
                    name="maskedCardNumber"
                    value={cardInfo.maskedCardNumber}
                    onChange={handleInputChange}
                    required
                    maxLength="19"
                    placeholder="xxxx xxxx xxxx xxxx"
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Cardholder Name</label>
                <input
                    type="text"
                    className="form-control"
                    name="cardholderName"
                    value={cardInfo.cardholderName}
                    onChange={handleInputChange}
                    required
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Expiration Date (MM/YY)</label>
                <input
                    type="text"
                    className="form-control"
                    name="expirationDate"
                    value={cardInfo.expirationDate}
                    onChange={handleInputChange}
                    required
                    placeholder="MM/YY"
                />
            </div>
        </>
    );
}

export default CardInfo;
