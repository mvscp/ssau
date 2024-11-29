public class ProductOnlineFactory implements ProductFactory {
    @Override
    public Product createInstance() {
        return new ProductOnline();
    }
}
