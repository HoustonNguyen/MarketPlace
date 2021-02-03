const initState = {
    selectedTitleId: null
}

const titleViewReducer = (state = initState, action) => {
    switch (action.type) {
        case 'SET_SELECTED_TITLE_ID':
            return {
                selectedTitleId: action.payload
            }
        case 'UNSET_SELECTED_TITLE_ID':
            return {
                selectedTitleId: null
            }
        default:
            return state
    }
}

export default titleViewReducer;