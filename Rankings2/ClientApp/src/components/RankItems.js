import React, { useState, useEffect } from 'react';
import MovieImagesArray from './MovieImages.js';
import RankingGrid from './RankingGrid'
const RankItems = ({ dataType = 1 }) => {
    const [items, setItems] = useState([]);

    useEffect(() => {
        fetch(`item/${dataType}`)
            .then((response) => response.json())
            .then((data) => {
                setItems(data);
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
            });
    }, [dataType]);

    return (
        <main>
            <RankingGrid items={items} imgArr={MovieImagesArray} />
            <div className='items-not-ranked'>
                {items.length > 0 ? (
                    items.map((item) => (
                        <div className='unranked-cell' key={`item-${item.id}`}>
                            <img src={MovieImagesArray.find(o => o.id === item.id)?.image} alt={`Movie ${item.id}`} />
                        </div>
                    ))
                ) : (
                    <div>Loading...</div>
                )}
            </div>
        </main>
    );
}

export default RankItems;