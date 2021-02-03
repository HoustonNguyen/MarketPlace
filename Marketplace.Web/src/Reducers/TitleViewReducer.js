const initState = {
    selectedTitleId: null,
    showErrorModal : false
}

const titleViewReducer = (state = initState, action) => {
    switch (action.type) {
        case 'SET_SELECTED_TITLE_ID':
            return {
                ...state,
                selectedTitleId: action.payload
            }
        case 'SET_SHOW_ERROR_MODAL':
            return {
                ...state,
                showErrorModal: action.payload
            }
        case 'UNSET_SELECTED_TITLE_ID':
            return {
                ...state,
                selectedTitleId: null
            }
        default:
            return state
    }
}

export default titleViewReducer;