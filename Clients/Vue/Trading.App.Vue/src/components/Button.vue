<template>
    <form>
        <div class="mb-3">
            <label for="stock" class="form-label">Stock</label>
            <input type="text" class="form-control" id="stock" v-model="stock">
        </div>
        <div class="mb-3">
            <label for="quantity" class="form-label">Quantity</label>
            <input type="text" class="form-control" id="quantity" v-model="quantity">
        </div>
        <div class="mb-3">
            <label for="price" class="form-label">Price</label>
            <input type="text" class="form-control" id="price" v-model="price">
        </div>
        <div class="mb-3">
            <label for="tradeDate" class="form-label">Date</label>
            <input type="text" class="form-control" id="tradeDate" v-model="tradeDate">
        </div>

        <div class="mb-3">
            <select class="form-select" id="buySell" v-model="buySell" aria-label="Default select example">
                <option selected>Open this select menu</option>
                <option value="Buy">Buy</option>
                <option value="Sell">Sell</option>
            </select>
        </div>
        <button type="submit" class="btn btn-primary" @click="onClick()">Submit</button>
    </form>

</template>

<script>
    export default {
        name: 'Button',
        data() {
            return {
                stock: '',
                tradeDate: '',
                quantity: '',
                price: '',
                buySell: ''
            }
        },
        methods: {
            async onClick() {
                
                const trade = {
                    Security: this.stock,
                    TradeDate: this.tradeDate,
                    Quantity: this.quantity,
                    Price: this.price,
                    BuySell: this.buySell
                }

                console.log(trade);

                const requestOptions = {
                    method: 'POST',
                    headers: {
                        'Content-type': 'application/json',
                    },
                    body: JSON.stringify(trade)
                };


                fetch('https://localhost:7006/api/PurchaseStock', requestOptions)
                    .then(async response => {

                        const data = await response.json();

                        if (!response.ok) {
                            const error = (data && data.message) || response.status;
                            return Promise.reject(error)
                        }
                    })
                    .catch(error => {
                        this.errorMessage = error;
                        console.error("Error is", error)
                    });
                }
                
            }
        }
</script>