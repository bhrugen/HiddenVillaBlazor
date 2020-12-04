redirectToCheckout = function (sessionId) {
    var stripe = Stripe('pk_test_51HuidRES6XguoEyXQbu9mQoeVsUgj2vZu5KcspDQd3fPojBsftW15gTQw4GjQ6Jt4AlCLKzta7iHAKp3Ccfi6jYr00mmbTUIZR');
    stripe.redirectToCheckout({
        sessionId: sessionId
    });
};