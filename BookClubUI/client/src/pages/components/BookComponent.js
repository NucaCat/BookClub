import React, {useState, useContext, useEffect} from 'react';

function BookComponent (props) {
    const [bookState, setBookState] = useState({
        id: props.id,
        bookName: props.bookName,
        alreadyRead: props.alreadyRead
        })
    
    const addToRead = (event) => {
        props.readChangeHandler({...bookState, ToAdd: true})
        setBookState({...bookState, alreadyRead: true})
    }

    const removeFromRead = (event) => {
        props.readChangeHandler({...bookState, ToAdd: false})
        setBookState({...bookState, alreadyRead: false})
    }
    return (
        <div className = 'BookComponent'>
            <div>
                <span>{bookState.bookName}</span>
            </div>
            <div>
                {bookState.alreadyRead 
                ? <input type='button' onClick={removeFromRead} value="Удалить книгу из прочитанного"/>
                : <input type='button' onClick={addToRead} value="Добавить книгу к прочитанным" />}

                {bookState.alreadyRead 
                ? <p>Эта книга уже прочитана!</p>
                : <p>Эта книга еще не прочитана.</p>}
            </div>
        </div>
    )
}

export default BookComponent