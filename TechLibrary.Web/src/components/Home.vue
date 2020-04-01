<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <b-form-input type="text" placeholder="Search By Title or Description" v-model="searchText" @keyup.enter="getFilteredBooksData"></b-form-input>
        <br />
        <b-link variant="primary" :to="{ name: 'book_add'}">Add Book</b-link>
        <b-table striped hover :items="results" :fields="fields" responsive="sm">
            <template v-slot:cell(thumbnailUrl)="data">
                <b-img :src="data.value" thumbnail fluid></b-img>
            </template>
            <template v-slot:cell(title_link)="data">
                <b-link :to="{ name: 'book_view', params: { 'id' : data.item.bookId}}">{{ data.item.title }}</b-link>

            </template>
        </b-table>

        <transition name="fade">
            <div v-show="dataIsLoading"
                 class="spinner-container">
                <div class="spinner" />
            </div>
        </transition>

        <div class="overflow-auto">
            <div>
                <b-pagination v-model="activePage"
                              :total-rows="resultsCount"
                              :per-page="resultsPerPage" first-number
                              last-number size="md"></b-pagination>
            </div>
        </div>

        <p v-if="error">{{ error.message }}</p>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'Home',
        props: {
            msg: String
        },
        data() {
            return {
                activePage: 1,
                baseUrl: 'https://localhost:5001/books',
                dataIsLoading: true,
                error: null,
                results: [],
                resultsCount: 0,
                resultsPerPage: 10,
                searchText: '',
                fields: [
                    { key: 'thumbnailUrl', label: 'Book Image' },
                    { key: 'title_link', label: 'Book Title', sortable: true, sortDirection: 'desc' },
                    { key: 'isbn', label: 'ISBN', sortable: true, sortDirection: 'desc' },
                    { key: 'descr', label: 'Description', sortable: true, sortDirection: 'desc' }

                ]
            }
        },
        computed: {
            url() {
                if (this.searchText.trim() == '') {
                    return `${this.baseUrl}/Books/${this.resultsPerPage}/${(this.activePage - 1) * this.resultsPerPage}`
                }
                else {
                    return `${this.baseUrl}/Books/${this.resultsPerPage}/${(this.activePage - 1) * this.resultsPerPage}/${this.search}`
                }
            },
            counturl() {
                if (this.searchText.trim() == '') {
                    return `${this.baseUrl}/BooksCount`
                }
                else {
                    return `${this.baseUrl}/BooksCount/${this.search}`
                }
            },
            pagesCount() {
                return Math.ceil(this.resultsCount / this.resultsPerPage)
            },
            search() {
                return this.searchText.trim().toLowerCase();
            }
        },
        watch: {
            activePage() {
                this.updateBooksData()
            }
        },
        created() {
            this.getBooksData()
        },
        methods: {
            getBooksData() {
                axios.get(this.url)
                    .then(response => {
                        this.getBooksCount()
                        this.setResults(response.data)
                    })
                    .catch(e => {
                        this.updateError(e)
                    })
                    .finally(() => this.dataIsLoading = false)
            },
            getBooksCount() {
                axios.get(this.counturl)
                    .then(response => {
                        this.setResultsCount(response.data)
                    })
                    .catch(e => {
                        this.updateError(e)
                    })
            },
            getFilteredBooksData() {
                this.activePage = 1
                this.getBooksData()
            },
            setActivePage(pageNumber) {
                this.activePage = pageNumber
            },
            setResultsCount(resCount) {
                this.resultsCount = resCount
            },
            setResults(res) {
                this.results = res
            },
            updateError(err) {
                this.error = err
            },
            removeResults() {
                this.results = []
            },
            removeError() {
                this.error = null
            },
            updateBooksData() {
                this.dataIsLoading = true
                this.removeResults()
                this.removeError()
                this.getBooksData()
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    .fade-enter-active, .fade-leave-active {
        transition: opacity .5s
    }

    .fade-enter, .fade-leave-to {
        opacity: 0
    }

    .spinner-container {
        position: fixed;
        z-index: 100;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        display: flex;
        align-items: center;
        background-color: rgba(0,0,0,.4);
    }

    .spinner {
        width: 20vw;
        height: 20vw;
        margin: auto;
        background-color: #fff;
        border-radius: 100%;
        animation: scale-out 1s infinite ease-in-out;
    }

    @keyframes scale-out {
        0% {
            transform: scale(0);
            opacity: 0.9
        }

        100% {
            transform: scale(1.0);
            opacity: 0;
        }
    }

</style>


