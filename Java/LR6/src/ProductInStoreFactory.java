public class ProductInStoreFactory implements ProductFactory {
    @Override
    public Product createInstance() {
        return new ProductInStore();
    }
}
