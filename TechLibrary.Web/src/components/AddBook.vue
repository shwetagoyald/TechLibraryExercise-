<template>
    <div>
        <h1>Add New Book</h1>
        <b-form @submit="onSubmit" @reset="onReset">
            <b-form-group>
                <b-form-file v-model="file"
                             :state="Boolean(file)"
                             placeholder="Choose a image or drop it here..."
                             drop-placeholder="Drop image here..." accept="image/*"></b-form-file>
            </b-form-group>
            <b-form-group>
                <b-form-input required v-model="book.ISBN" placeholder="Enter book ISBN" :maxlength="50"></b-form-input>
            </b-form-group>
            <b-form-group>
                <b-form-input required v-model="book.title" placeholder="Enter book title" :maxlength="100"></b-form-input>
            </b-form-group>
            <b-form-group>
                <b-form-textarea required type="text" v-model="book.ShortDescr" rows="3" max-rows="6" :maxlength="500" placeholder="Enter book short description"></b-form-textarea>
            </b-form-group>
            <b-button to="/" variant="primary">Back</b-button>
            <b-button type="reset" variant="danger" class="float-right">Reset</b-button>
            <b-button type="submit" variant="success" class="float-right mr-2">Submit</b-button>
        </b-form>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'AddBook',
        props: ["id"],
        data: () => ({
            book: [],
            error: null,
            file: null,
            baseUrl: 'https://localhost:5001/books',
        }),
        computed: {
            geturl() {
                return `${this.baseUrl}/new`
            }
        },
        mounted() {
            axios.get(this.geturl)
                .then(response => {
                    this.book = response.data;
                });
        },
        methods: {
            onSubmit(evt) {
                evt.preventDefault()
                axios.post(
                    `${this.baseUrl}/Add`,
                    {
                        Title: this.book.title,
                        ShortDescr: this.book.ShortDescr,
                        ThumbnailUrl: null, // need to upload image file to S3
                        ISBN: this.book.ISBN
                    })
                    .catch(e => {
                        this.updateError(e)
                    })
                    .finally(() => this.$router.push('/'))
            },
            onReset(evt) {
                evt.preventDefault()
                // Reset our form values
                this.book.title = ''
                this.book.ShortDescr = ''
                this.book.thumbnailUrl = null
                this.book.ISBN = ''
                this.show = false
                this.$nextTick(() => {
                    this.show = true
                })
            },
            updateError(err) {
                this.error = err
            },
        }
    }
</script>